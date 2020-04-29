using BackOff.Shared.Models;
using System;

namespace BackOff.Shared
{
    public class OtpController
    {
        private readonly IWela wela;
        private readonly IOtpCode otpCode;
        private Func<DateTime> utcNowFn = () => DateTime.UtcNow;

        public OtpController(ICounter requestCounter, ICounter verifyCounter, IWela wela, IOtpCode otpCode, Func<DateTime> utcNowFn)
            : this(requestCounter, verifyCounter, wela, otpCode)
            => this.utcNowFn = utcNowFn;

        public OtpController(ICounter requestCounter, ICounter verifyCounter, IWela wela, IOtpCode otpCode)
        {
            RequestCounter = requestCounter;
            VerifyCounter = verifyCounter;
            this.wela = wela;
            this.otpCode = otpCode;
        }

        public ICounter RequestCounter { get; set; }
        public ICounter VerifyCounter { get; set; }

        public Otp RequestOtp(string phone)
        {
            var attemption = RequestCounter.GetAttemption(phone);
            const int FirstPenalty = 4;
            var isNoPenalty = attemption < FirstPenalty || wela.HasExpired(phone);
            if (isNoPenalty)
            {
                const int shortDelayInMinute = 1;
                const int longDelayInMinute = 30;
                const int ShortDelayAttemption = 3;
                var isShortDelay = attemption < ShortDelayAttemption;
                var delayTimeInMinute = isShortDelay ? shortDelayInMinute : longDelayInMinute;
                var unlockedTime = utcNowFn().AddMinutes(delayTimeInMinute);
                wela.SetUnlockedTime(phone, unlockedTime);
                return new Otp
                {
                    Code = otpCode.SetCode(phone),
                    BackOff = new Models.BackOff
                    {
                        UnlockedTime = unlockedTime,
                        ReqAttempt = RequestCounter.Increment(phone),
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
            var attemption = VerifyCounter.GetAttemption(phone);
            const int MaxAttemptCount = 7;
            var isAllow = attemption < MaxAttemptCount;
            if (isAllow == false)
            {
                return new Result { AttemptCount = attemption };
            }

            var expected = otpCode.GetCode(phone);
            var isCodeValid = code == expected;
            if (isCodeValid)
            {
                RequestCounter.Reset(phone);
            }

            return new Result
            {
                Passed = isCodeValid,
                AttemptCount = VerifyCounter.Increment(phone),
            };
        }
    }
}
