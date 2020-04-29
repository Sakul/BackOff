namespace BackOff.Shared
{
    public interface IOtpCode
    {
        string SetCode(string phone);
        string GetCode(string phone);
    }
}
