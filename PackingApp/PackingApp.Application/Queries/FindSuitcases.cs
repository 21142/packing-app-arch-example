using PackingApp.Application.DTO;
using PackingApp.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace PackingApp.Application.Queries
{
    public class FindSuitcases : IQuery<IEnumerable<SuitcaseDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
