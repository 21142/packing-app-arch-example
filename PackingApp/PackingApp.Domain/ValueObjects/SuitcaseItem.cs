using PackingApp.Domain.Exceptions;

namespace PackingApp.Domain.ValueObjects
{
    public record SuitcaseItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public bool IsAlreadyPacked { get; }
        public bool IsPacked { get; init; }

        public SuitcaseItem(string name, int quantity, bool isAlreadyPacked = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptySuitcaseNameException();
            }

            Name = name;
            Quantity = quantity;
            IsAlreadyPacked = isAlreadyPacked;
        }
    }
}
