using PackingApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingApp.Domain.Policies
{
    public class DefaultPolicy : ISuitcaseItemsPolicy
    {
        public bool IsAppropriate(PolicyData policyData) => true;

        public IEnumerable<SuitcaseItem> PrepareSuitcase(PolicyData policyData)
            => new List<SuitcaseItem>
            {
                new("Socks", policyData.Days),
                new("Drawers", policyData.Days),
                new("T-shirts", policyData.Days),
                new("Pants", policyData.Days / 7)
            };
    }
}
