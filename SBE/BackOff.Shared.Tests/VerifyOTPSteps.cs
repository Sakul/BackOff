using BackOff.Shared.Models;
using BackOff.Shared.Tests.Models;
using FluentAssertions;
using Moq;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BackOff.Shared.Tests
{
    [Binding]
    public class VerifyOTPSteps
    {
        private Result actual;
        private readonly OtpContext ctx;

        public VerifyOTPSteps(OtpContext ctx)
            => this.ctx = ctx;

        [Given(@"ในระบบมีข้อมูลการขอรหัส OTP เป็นดังนี้")]
        public void GivenในระบบมขอมลการขอรหสOTPเปนดงน(Table table)
        {
            var data = table.CreateSet<VerifyOtpRecord>().ToList();
            ctx.VerifyCounterMock
                .Setup(it => it.GetAttemption(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone).AttemptCount);
            ctx.VerifyCounterMock
                .Setup(it => it.Increment(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone).AttemptCount + 1);
            ctx.OtpCodeMock
                .Setup(it => it.GetCode(It.IsAny<string>()))
                .Returns<string>(phone => data.FirstOrDefault(it => it.Phone == phone).Code);
        }

        [When(@"ทำการยืนยัน OTP ของเบอร์ '(.*)' ด้วยรหัส '(.*)'")]
        public void WhenทำการยนยนOTPของเบอรดวยรหส(string phone, string code)
            => actual = ctx.Sut.VerifyOtp(phone, code);

        [Then(@"ระบบกำหนดให้การยืนยันผ่าน โดยเป็นการทำครั้งที่ '(.*)'")]
        public void Thenระบบใหการยนยนผานโดยเปนการทำครงท(int expectedAttemptCount)
        {
            actual.Should().NotBeNull();
            actual.Passed.Should().BeTrue();
            actual.AttemptCount.Should().Be(expectedAttemptCount);
        }

        [Then(@"ระบบทำการรีเซ็ต attempt count ของเบอร์ '(.*)'")]
        public void ThenระบบทำการรเซตAttemptCountของเบอร(string phone)
            => ctx.RequestCounterMock.Verify(it => it.Reset(It.Is<string>(actual => actual == phone)), Times.Exactly(1));

        [Then(@"ระบบกำหนดให้การยืนยันไม่ผ่าน โดยเป็นการทำครั้งที่ '(.*)'")]
        public void Thenระบบกำหนดใหการยนยนไมผานโดยเปนการทำครงท(int expectedAttemptCount)
        {
            actual.Should().NotBeNull();
            actual.Passed.Should().BeFalse();
            actual.AttemptCount.Should().Be(expectedAttemptCount);
        }

        [Then(@"ระบบไม่รีเซ็ต attempt count")]
        public void ThenระบบไมรเซตAttemptCount()
            => ctx.RequestCounterMock.Verify(it => it.Reset(It.IsAny<string>()), Times.Never());
    }
}
