using BackOff.Shared.Tests.Models;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace BackOff.Shared.Tests
{
    [Binding]
    public class BackgroundSteps
    {
        private readonly OtpContext ctx;

        public BackgroundSteps(OtpContext ctx)
            => this.ctx = ctx;

        [Given(@"ระบบทำการกำหนดค่าเริ่มต้นของการทำ OTP")]
        public void GivenระบบทำการกำหนดคาเรมตนของการทำOTP()
        {
            ctx.CurrenTimeFn = () => ctx.CurrentTime;
            var mock = new MockRepository(MockBehavior.Default);
            ctx.RequestCounterMock = mock.Create<ICounter>();
            ctx.VerifyCounterMock = mock.Create<ICounter>();
            ctx.WelaMock = mock.Create<IWela>();
            ctx.OtpCodeMock = mock.Create<IOtpCode>();
            ctx.Sut = new OtpController(
                ctx.RequestCounterMock.Object,
                ctx.VerifyCounterMock.Object,
                ctx.WelaMock.Object,
                ctx.OtpCodeMock.Object,
                ctx.CurrenTimeFn);
        }

        [Given(@"รหัสยืนยัน OTP ในรอบนี้คือ '(.*)'")]
        public void GivenรหสยนยนOTPในรอบนคอ(string code)
            => ctx.OtpCodeMock
                .Setup(it => it.SetCode(It.IsAny<string>()))
                .Returns<string>(_ => code);

        [Given(@"ขณะนี้เวลา '(.*)'")]
        public void Givenขณะนเวลา(DateTime currentTime)
           => ctx.CurrentTime = currentTime;
    }
}
