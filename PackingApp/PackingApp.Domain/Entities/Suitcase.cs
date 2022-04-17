using PackingApp.Domain.Common;
using PackingApp.Domain.Events;
using PackingApp.Domain.Exceptions;
using PackingApp.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PackingApp.Domain.Entities
{
    public class Suitcase : AggregateRoot<SuitcaseId>
    {
        public SuitcaseId Id { get; private set; }

        private SuitcaseName _name;
        private Location _location;

        private readonly LinkedList<SuitcaseItem> _clothes = new();

        internal Suitcase(SuitcaseId id, SuitcaseName name, Location location)
        {
            Id = id;
            _name = name;
            _location = location;
        }

        private Suitcase()
        {
        }

        public void AddSuitcaseItem(SuitcaseItem suitcaseItem)
        {
            var alreadyPacked = _clothes.Any(c => c.Name == suitcaseItem.Name);

            if (alreadyPacked)
            {
                throw new SuitcaseItemAlreadyPresentException(_name, suitcaseItem.Name);
            }

            _clothes.AddLast(suitcaseItem);
            AddEvent(new SuitcaseItemAddedEvent(this, suitcaseItem));
        }

        public void AddSuitcaseItems(IEnumerable<SuitcaseItem> suitcaseItems)
        {
            foreach (var suitcaseItem in suitcaseItems)
            {
                AddSuitcaseItem(suitcaseItem);
            }
        }

        public void PackSuitcaseItem(string suitcaseItemName)
        {
            var suitcaseItem = GetSuitcaseItem(suitcaseItemName);
            var packedSuitcaseItem = suitcaseItem with { IsPacked = true };

            _clothes.Find(suitcaseItem).Value = packedSuitcaseItem;
            AddEvent(new SuitcaseItemPackedEvent(this, suitcaseItem));
        }

        public void RemoveSuitcaseItem(string suitcaseItemName)
        {
            var suitcaseItem = GetSuitcaseItem(suitcaseItemName);
            _clothes.Remove(suitcaseItem);
            AddEvent(new SuitcaseItemRemovedEvent(this, suitcaseItem));
        }

        #region Private

        private SuitcaseItem GetSuitcaseItem(string suitcaseItemName)
        {
            var suitcaseItem = _clothes.SingleOrDefault(i => i.Name == suitcaseItemName);

            if (suitcaseItem is null)
            {
                throw new SuitcaseItemNotFoundException(suitcaseItemName);
            }

            return suitcaseItem;
        }

        #endregion
    }
}
