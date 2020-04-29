namespace BackOff.Shared.Tests.Models
{
    public class VerifyOtpRecord
    {
        public string Phone { get; set; }
        public string Code { get; set; }
        public int AttemptCount { get; set; }
    }
}
