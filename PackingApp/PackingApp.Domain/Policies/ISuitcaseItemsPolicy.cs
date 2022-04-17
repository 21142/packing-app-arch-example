using PackingApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingApp.Domain.Policies
{
    public interface ISuitcaseItemsPolicy
    {
        bool IsAppropriate(PolicyData policyData);
        IEnumerable<SuitcaseItem> PrepareSuitcase(PolicyData policyData);
    }
}
