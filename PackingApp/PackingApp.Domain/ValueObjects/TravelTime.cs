using PackingApp.Domain.Exceptions;

namespace PackingApp.Domain.ValueObjects
{
    public record TravelTime
    {
        public int ValueInDays { get; }

        public TravelTime(int timeInDays)
        {
            if (timeInDays < 1 && timeInDays > 365)
            {
                throw new InvalidTravelTimeException(timeInDays);
            }

            ValueInDays = timeInDays;
        }

        public static implicit operator TravelTime(int timeInDays) => new(timeInDays);

        public static implicit operator int(TravelTime timeInDays) => timeInDays.ValueInDays;
    }
}
