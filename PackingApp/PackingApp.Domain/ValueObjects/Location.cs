using System.Linq;

namespace PackingApp.Domain.ValueObjects
{
    public record Location(string Country, string City)
    {
        public static Location CreateLocationFromString(string address)
        {
            var splitStringByComma = address.Split(',');
            return new Location(splitStringByComma.First(), splitStringByComma.Last());
        }

        public override string ToString() => $"{Country},{City}";

    }
}
