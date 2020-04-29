using System;

namespace BackOff.Shared.Models
{
    public class BackOff
    {
        public int ReqAttempt { get; set; }
        public DateTime UnlockedTime { get; set; }
    }
}
