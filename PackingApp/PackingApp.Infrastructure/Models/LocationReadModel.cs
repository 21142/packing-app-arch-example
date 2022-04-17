using System.Linq;

namespace PackingApp.Infrastructure.Models
{
    public class LocationReadModel
    {
        public string Country { get; set; }
        public string City { get; set; }

        public static LocationReadModel Create(string fullLocation)
        {
            var splittedLocation = fullLocation.Split(", ");
            return new LocationReadModel
            {
                Country = splittedLocation.First(),
                City = splittedLocation.Last()
            };
        }

        public override string ToString()
            => $"{Country}, {City}";
    }
}
