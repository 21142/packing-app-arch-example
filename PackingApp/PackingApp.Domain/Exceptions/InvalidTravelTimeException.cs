namespace PackingApp.Domain.Exceptions
{
    public class InvalidTravelTimeException : BaseException
    {
        public int Days { get; }

        public InvalidTravelTimeException(int days) : base($"We don't support travelling for {days} days")
            => Days = days;
    }
}
