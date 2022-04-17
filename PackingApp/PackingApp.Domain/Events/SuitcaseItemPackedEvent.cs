using PackingApp.Domain.Entities;
using PackingApp.Domain.ValueObjects;

namespace PackingApp.Domain.Events
{
    public record SuitcaseItemPackedEvent(Suitcase Suitcase, SuitcaseItem SuitcaseItem) : IDomainEvent;

}
