using Moq;
using System;

namespace BackOff.Shared.Tests.Models
{
    public class OtpContext
    {
        public DateTime CurrentTime { get; set; }
        public Func<DateTime> CurrenTimeFn { get; set; }
        public OtpController Sut { get; set; }
        public Mock<ICounter> RequestCounterMock { get; set; }
        public Mock<ICounter> VerifyCounterMock { get; set; }
        public Mock<IWela> WelaMock { get; set; }
        public Mock<IOtpCode> OtpCodeMock { get; set; }
    }
}
