namespace BackOff.Shared.Models
{
    public class Result
    {
        public bool Passed { get; set; }
        public int AttemptCount { get; set; }
    }
}
