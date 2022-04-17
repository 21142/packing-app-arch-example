using PackingApp.Domain.Entities;
using PackingApp.Domain.Enums;
using PackingApp.Domain.ValueObjects;

namespace PackingApp.Domain.Factories
{
    public interface ISuitcaseFactory
    {
        Suitcase Create(SuitcaseId id, SuitcaseName name, Location location);
        Suitcase CreateWithEssentialClothes(SuitcaseId id, SuitcaseName name, Location location, TravelTime days, Gender gender, Temperature temp);
    }
}
