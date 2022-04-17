using PackingApp.Domain.Entities;
using PackingApp.Domain.Enums;
using PackingApp.Domain.Policies;
using PackingApp.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PackingApp.Domain.Factories
{
    public class SuitcaseFactory : ISuitcaseFactory
    {
        private readonly IEnumerable<ISuitcaseItemsPolicy> _policies;

        public SuitcaseFactory(IEnumerable<ISuitcaseItemsPolicy> policies)
            => _policies = policies;

        public Suitcase Create(SuitcaseId id, SuitcaseName name, Location location)
            => new(id, name, location);

        public Suitcase CreateWithEssentialClothes(SuitcaseId id, SuitcaseName name, Location location, TravelTime days,
            Gender gender, Temperature temp)
        {
            var policyData = new PolicyData(location, temp, days, gender);
            var appropriatePolicies = _policies.Where(p => p.IsAppropriate(policyData));
            var suitcaseItems = appropriatePolicies.SelectMany(p => p.PrepareSuitcase(policyData));
            var suitcase = Create(id, name, location);

            suitcase.AddSuitcaseItems(suitcaseItems);

            return suitcase;
        }
    }
}
