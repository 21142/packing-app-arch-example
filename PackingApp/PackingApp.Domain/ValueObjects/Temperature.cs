using PackingApp.Domain.Exceptions;

namespace PackingApp.Domain.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }

        public Temperature(double temp)
        {
            if (temp < -30 || temp > 60)
            {
                throw new InvalidTemperatureException(temp);
            }

            Value = temp;
        }

        public static implicit operator Temperature(double temp) => new(temp);

        public static implicit operator double(Temperature temp) => temp.Value;
    }
}
