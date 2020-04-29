using System;

namespace BackOff.Shared.Tests.Models
{
    public class PhoneRecord
    {
        public string Phone { get; set; }
        public int AttemptCount { get; set; }
        public DateTime UnlockedTime { get; set; }
    }
}
