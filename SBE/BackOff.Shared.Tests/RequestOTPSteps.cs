using BackOff.Shared.Models;
using BackOff.Shared.Tests.Models;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BackOff.Shared.Tests
{
    [Binding]
    public class RequestOTPSteps
    {
        private DateTime currentTime;
        private Func<DateTime> currenTimeFn;
        private OtpController sut;
        private Mock<ICounter> requestCounterMock;
        private Mock<IWela> welaMock;
        private Otp actual;

        public RequestOTPSteps()
        {
            currenTimeFn = () => currentTime;
            var mock = new MockRepository(MockBehavior.Default);
            requestCounterMock = mock.Create<ICounter>();
            welaMock = mock.Create<IWela>();
            sut = new OtpController(requestCounterMock.Object, welaMock.Object, currenTimeFn);
        }

        [Given(@"รายการเบอร์โทรในระบบเป็นดังนี้")]
        public void Givenรายการเบอรโทรในระบบเปนดงน(Table table)
        {
            var data = table.CreateSet<PhoneRecord>().ToList();
            requestCounterMock
                .Setup(it => it.GetAttemption(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone)?.AttemptCount ?? 0);
            requestCounterMock
                .Setup(it => it.Increment(It.IsAny<string>()))
                .Returns<string>(phone => (data.FirstOrDefault(it => it.Phone == phone)?.AttemptCount ?? 0) + 1);
            welaMock
                .Setup(it => it.GetUnlockedTime(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone).UnlockedTime);
            welaMock
                .Setup(it => it.HasExpired(It.IsAny<string>()))
                .Returns<string>(phone => currentTime >= data.FirstOrDefault(it => it.Phone == phone).UnlockedTime);
        }

        [Given(@"ขณะนี้เวลา '(.*)'")]
        public void Givenขณะนเวลา(DateTime currentTime)
            => this.currentTime = currentTime;

        [When(@"เบอร์โทร '(.*)' ขอทำรายการ")]
        public void Whenเบอรโทรขอทำรายการ(string phone)
            => actual = sut.RequestOtp(phone);

        [Then(@"ขอดำเนินรายการได้ โดยเป็นการขอครั้งที่ '(.*)' และจะขอทำรายการได้ใหม่เมื่อเวลา '(.*)'")]
        public void Thenขอดำเนนรายการได(int expectedReqAttempt, DateTime expectedUnlockedTime)
        {
            actual.Should().NotBeNull();
            actual.Code.Should().NotBeNullOrWhiteSpace();
            actual.BackOff.ReqAttempt.Should().Be(expectedReqAttempt);
            actual.BackOff.UnlockedTime.Should().Be(expectedUnlockedTime);

            requestCounterMock.Verify(it => it.Increment(It.IsAny<string>()), Times.Exactly(1));
            welaMock.Verify(it => it.SetUnlockedTime(It.IsAny<string>(), It.Is<DateTime>(actual => actual == expectedUnlockedTime)), Times.Exactly(1));
        }

        [Then(@"ขอดำเนินรายการไม่ได้ โดยเป็นการขอครั้งที่ '(.*)' และจะขอทำรายการได้ใหม่เมื่อเวลา '(.*)'")]
        public void Thenขอดำเนนรายการไมไดโดยเปนการขอครงทและจะขอทำรายการไดใหมเมอเวลา(int expectedReqAttempt, DateTime expectedUnlockedTime)
        {
            actual.Should().NotBeNull();
            actual.Code.Should().BeNull();
            actual.BackOff.ReqAttempt.Should().Be(expectedReqAttempt);
            actual.BackOff.UnlockedTime.Should().Be(expectedUnlockedTime);

            requestCounterMock.Verify(it => it.Increment(It.IsAny<string>()), Times.Never());
            welaMock.Verify(it => it.SetUnlockedTime(It.IsAny<string>(), It.IsAny<DateTime>()), Times.Never());
        }
    }
}
