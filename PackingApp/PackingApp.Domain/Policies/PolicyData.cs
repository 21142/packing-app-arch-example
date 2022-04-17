using PackingApp.Domain.ValueObjects;

namespace PackingApp.Domain.Policies
{
    public record PolicyData(Location Location, ValueObjects.Temperature Temperature, TravelTime Days, Enums.Gender Gender);
}
