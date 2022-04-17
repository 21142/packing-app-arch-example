using PackingApp.Domain.Exceptions;

namespace PackingApp.Domain.ValueObjects
{
    public record SuitcaseName
    {
        public string Value { get; }

        public SuitcaseName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptySuitcaseNameException();
            }
            Value = value;
        }

        public static implicit operator SuitcaseName(string name) => new(name);

        public static implicit operator string(SuitcaseName name) => name.Value;
    }
}
