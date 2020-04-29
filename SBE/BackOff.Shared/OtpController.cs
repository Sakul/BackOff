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
        private Func<DateTime> utcNowFn = () => DateTime.UtcNow;

        public OtpController(ICounter requestCounter, IWela wela, Func<DateTime> utcNowFn)
            : this(requestCounter, wela)
            => this.utcNowFn = utcNowFn;

        public OtpController(ICounter requestCounter, IWela wela)
        {
            this.requestCounter = requestCounter;
            this.wela = wela;
        }

        public Otp RequestOtp(string phone)
        {
            var attemption = requestCounter.GetAttemption(phone);
            const int FirstPenalty = 4;
            var isNoPenalty = attemption < FirstPenalty || wela.HasExpired(phone);
            if (isNoPenalty)
            {
                const int ShortDelayAttemption = 3;
                var isShortDelay = attemption < ShortDelayAttemption;
                var delayTimeInMinute = isShortDelay ? shortDelayInMinute : longDelayInMinute;
                var unlockedTime = utcNowFn().AddMinutes(delayTimeInMinute);
                wela.SetUnlockedTime(phone, unlockedTime);
                return new Otp
                {
                    Code = Guid.NewGuid().ToString(),
                    BackOff = new Models.BackOff
                    {
                        UnlockedTime = unlockedTime,
                        ReqAttempt = requestCounter.Increment(phone),
                    }
                };
            }

            return new Otp
            {
                BackOff = new Models.BackOff
                {
                    ReqAttempt = attemption,
                    UnlockedTime = wela.GetUnlockedTime(phone),
                }
            };
        }

        public Result VerifyOtp(string phone, string code)
        {
            throw new Exception();
        }
    }
}
