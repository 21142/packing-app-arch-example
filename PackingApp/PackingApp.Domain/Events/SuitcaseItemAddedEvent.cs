using PackingApp.Domain.Entities;
using PackingApp.Domain.ValueObjects;

namespace PackingApp.Domain.Events
{
    public record SuitcaseItemAddedEvent(Suitcase Suitcase, SuitcaseItem SuitcaseItem) : IDomainEvent;
}
