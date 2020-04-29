using BackOff.Shared.Models;
using System;

namespace BackOff.Shared
{
    public class OtpController
    {
        private const int shortDelayInMinute = 1;
        private const int longDelayInMinute = 30;
        private readonly ICounter requestCounter;
        private readonly IWela wela;
        private Func<DateTime> utcNowFn;

        public OtpController(ICounter requestCounter, IWela wela, Func<DateTime> utcNowFn)
        {
            this.requestCounter = requestCounter;
            this.wela = wela;
            this.utcNowFn = utcNowFn;
        }

        public Otp RequestOtp(string phone)
        {
            var attemption = requestCounter.GetAttemption(phone);
            const int FirstPenalty = 4;
            var isNoPenalty = attemption < FirstPenalty;
            if (isNoPenalty)
            {
                const int ShortDelayAttemption = 3;
                var isShortDelay = attemption < ShortDelayAttemption;
                var delayTimeInMinute = isShortDelay ? shortDelayInMinute : longDelayInMinute;
                var unlockedTime = utcNowFn().AddMinutes(delayTimeInMinute);
                wela.SetUnlockedTime(phone, unlockedTime);
                return new Otp
                {
                    ShouldSendOTP = true,
                    UnlockedTime = unlockedTime,
                    Code = Guid.NewGuid().ToString(),
                    ReqAttempt = requestCounter.Increment(phone),
                };
            }
            else if (wela.HasExpired(phone))
            {
                var unlockedTime = utcNowFn().AddMinutes(longDelayInMinute);
                wela.SetUnlockedTime(phone, unlockedTime);
                return new Otp
                {
                    ShouldSendOTP = true,
                    UnlockedTime = unlockedTime,
                    Code = Guid.NewGuid().ToString(),
                    ReqAttempt = requestCounter.Increment(phone),
                };
            }
            else
            {
                return new Otp
                {
                    ReqAttempt = attemption,
                    UnlockedTime = wela.GetUnlockedTime(phone),
                };
            }
        }

        public Result VerifyOtp(string phone, string code)
        {
            throw new Exception();
        }
    }
}
