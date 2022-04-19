using PackingApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PackingApp.Domain.Policies.Gender
{
    public class MalePolicy : ISuitcaseItemsPolicy
    {
        public bool IsAppropriate(PolicyData policyData)
            => policyData.Gender is Enums.Gender.Male;

        public IEnumerable<SuitcaseItem> PrepareSuitcase(PolicyData policyData)
            => new List<SuitcaseItem>
            {
                new("Sweatpants", 2),
                new("Hoodie", 2),
                new("Headphones", 1)
            };
    }
}
