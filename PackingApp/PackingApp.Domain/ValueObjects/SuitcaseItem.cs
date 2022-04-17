using PackingApp.Domain.Exceptions;

namespace PackingApp.Domain.ValueObjects
{
    public record SuitcaseItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public bool IsPacked { get; init; }

        public SuitcaseItem(string name, int quantity, bool isPacked = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptySuitcaseNameException();
            }

            Name = name;
            Quantity = quantity;
            IsPacked = isPacked;
        }
    }
}
