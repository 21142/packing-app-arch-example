using Microsoft.EntityFrameworkCore;
using PackingApp.Application.DTO;
using PackingApp.Application.Queries;
using PackingApp.Infrastructure.Models;
using PackingApp.Infrastructure.Persistence;
using PackingApp.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackingApp.Infrastructure.QueryHandlers
{
    public class FindSuitcaseHandler : IQueryHandler<FindSuitcases, IEnumerable<SuitcaseDto>>
    {
        private readonly DbSet<SuitcaseReadModel> _suitcases;

        public FindSuitcaseHandler(ReadDbContext context)
            => _suitcases = context.Suitcases;

        public async Task<IEnumerable<SuitcaseDto>> HandleAsync(FindSuitcases query)
        {
            var searchQuery = _suitcases.Include(s => s.SuitcaseItems)
                .AsQueryable();

            if (query.SearchPhrase is not null)
            {
                searchQuery = searchQuery.Where(s => 
                    EF.Functions.Like(s.Name, $"%{query.SearchPhrase}%"));
            }

            return await searchQuery.Select(s => s.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
