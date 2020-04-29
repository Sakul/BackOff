using System;

namespace BackOff.Shared.Models
{
    public class Otp
    {
        public bool ShouldSendOTP { get; set; }
        public DateTime UnlockedTime { get; set; }
        public int ReqAttempt { get; set; }
        public string Code { get; set; }
    }
}
