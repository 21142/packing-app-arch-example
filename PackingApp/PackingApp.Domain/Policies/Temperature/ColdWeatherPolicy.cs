using PackingApp.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackingApp.Domain.Policies.Temperature
{
    public class ColdWeatherPolicy : ISuitcaseItemsPolicy
    {
        public bool IsAppropriate(PolicyData policyData)
            => policyData.Temperature < 0;

        public IEnumerable<SuitcaseItem> PrepareSuitcase(PolicyData policyData)
            => new List<SuitcaseItem>
            {
                new("Coat", 1),
                new("Mittens", 1),
                new("Beanie", 2)
            };
    }
}
