using PackingApp.Domain.ValueObjects;
using PackingApp.Shared.Abstractions.Exceptions;

namespace PackingApp.Application.Exceptions
{
    public class MissingLocationTemperatureException : BaseException
    {
        public MissingLocationTemperatureException(Location location) : base($"Temperature couldn't be retrieved for location: {location.City}, {location.Country}!")
        {
        }
    }
}
