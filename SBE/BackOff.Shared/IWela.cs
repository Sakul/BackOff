using System;

namespace BackOff.Shared
{
    public interface IWela
    {
        bool HasExpired(string phone);
        DateTime GetUnlockedTime(string phone);
        void SetUnlockedTime(string phone, DateTime unlockedTime);
    }
}
