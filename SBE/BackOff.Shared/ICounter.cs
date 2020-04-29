namespace BackOff.Shared
{
    public interface ICounter
    {
        int Increment(string phone);
        int GetAttemption(string phone);
        void Reset(string phone);
    }
}
