using PackingApp.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackingApp.Domain.Policies.Temperature
{
    public class HotWeatherPolicy : ISuitcaseItemsPolicy
    {
        public bool IsAppropriate(PolicyData policyData)
            => policyData.Temperature > 20;

        public IEnumerable<SuitcaseItem> PrepareSuitcase(PolicyData policyData)
            => new List<SuitcaseItem>
            {
                new("Sunscreen", 1),
                new("Towel", 2),
                new("Swimmers", 2)
            };
    }
}
