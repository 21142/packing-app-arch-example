using PackingApp.Domain.ValueObjects;
using System.Collections.Generic;

namespace PackingApp.Domain.Policies.Gender
{
    public class FemalePolicy : ISuitcaseItemsPolicy
    {
        public bool IsAppropriate(PolicyData policyData)
            => policyData.Gender is Enums.Gender.Female;

        public IEnumerable<SuitcaseItem> PrepareSuitcase(PolicyData policyData)
            => new List<SuitcaseItem>
            {
                new("Dress", 2),
                new("Purse", 2),
                new("Hairbrush", 1)
            };
    }
}
