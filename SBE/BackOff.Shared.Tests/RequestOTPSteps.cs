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
        public Otp actual;

        private readonly OtpContext ctx;

        public RequestOTPSteps(OtpContext ctx)
            => this.ctx = ctx;

        [Given(@"รายการเบอร์โทรในระบบเป็นดังนี้")]
        public void Givenรายการเบอรโทรในระบบเปนดงน(Table table)
        {
            var data = table.CreateSet<PhoneRecord>().ToList();
            ctx.RequestCounterMock
                .Setup(it => it.GetAttemption(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone)?.AttemptCount ?? 0);
            ctx.RequestCounterMock
                .Setup(it => it.Increment(It.IsAny<string>()))
                .Returns<string>(phone => (data.FirstOrDefault(it => it.Phone == phone)?.AttemptCount ?? 0) + 1);
            ctx.WelaMock
                .Setup(it => it.GetUnlockedTime(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone).UnlockedTime);
            ctx.WelaMock
                .Setup(it => it.HasExpired(It.IsAny<string>()))
                .Returns<string>(phone => ctx.CurrentTime >= data.FirstOrDefault(it => it.Phone == phone).UnlockedTime);
        }

        [When(@"เบอร์โทร '(.*)' ขอทำรายการ")]
        public void Whenเบอรโทรขอทำรายการ(string phone)
            => actual = ctx.Sut.RequestOtp(phone);

        [Then(@"ขอดำเนินรายการได้ โดยเป็นการขอครั้งที่ '(.*)' และจะขอทำรายการได้ใหม่เมื่อเวลา '(.*)'")]
        public void Thenขอดำเนนรายการได(int expectedReqAttempt, DateTime expectedUnlockedTime)
        {
            actual.Should().NotBeNull();
            actual.Code.Should().NotBeNullOrWhiteSpace();
            actual.BackOff.ReqAttempt.Should().Be(expectedReqAttempt);
            actual.BackOff.UnlockedTime.Should().Be(expectedUnlockedTime);

            ctx.RequestCounterMock.Verify(it => it.Increment(It.IsAny<string>()), Times.Exactly(1));
            ctx.OtpCodeMock.Verify(it => it.SetCode(It.IsAny<string>()), Times.Exactly(1));
            ctx.WelaMock.Verify(it => it.SetUnlockedTime(It.IsAny<string>(), It.Is<DateTime>(actual => actual == expectedUnlockedTime)), Times.Exactly(1));
        }

        [Then(@"รหัสยืนยัน OTP ที่ระบบส่งให้คือ '(.*)'")]
        public void ThenรหสยนยนOTPทระบบสงใหคอ(string expectedCode)
            => actual.Code.Should().Be(expectedCode);

        [Then(@"ขอดำเนินรายการไม่ได้ โดยเป็นการขอครั้งที่ '(.*)' และจะขอทำรายการได้ใหม่เมื่อเวลา '(.*)'")]
        public void Thenขอดำเนนรายการไมไดโดยเปนการขอครงทและจะขอทำรายการไดใหมเมอเวลา(int expectedReqAttempt, DateTime expectedUnlockedTime)
        {
            actual.Should().NotBeNull();
            actual.Code.Should().BeNull();
            actual.BackOff.ReqAttempt.Should().Be(expectedReqAttempt);
            actual.BackOff.UnlockedTime.Should().Be(expectedUnlockedTime);

            ctx.RequestCounterMock.Verify(it => it.Increment(It.IsAny<string>()), Times.Never());
            ctx.OtpCodeMock.Verify(it => it.SetCode(It.IsAny<string>()), Times.Never());
            ctx.WelaMock.Verify(it => it.SetUnlockedTime(It.IsAny<string>(), It.IsAny<DateTime>()), Times.Never());
        }
    }
}
