namespace PackingApp.Domain.Exceptions
{
    public class InvalidTemperatureException : BaseException
    {
        public double Temperature { get; }
        public InvalidTemperatureException(double temp) : base($"{temp} is not a valid temperature!")
            => Temperature = temp;
    }
}
