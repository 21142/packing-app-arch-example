using PackingApp.Domain.Events;
using System.Collections.Generic;

namespace PackingApp.Domain.Common
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new();

        protected void AddEvent(IDomainEvent e)
        {
            _events.Add(e);
        }

        public void ClearAllEvents() => _events.Clear();
    }
}
