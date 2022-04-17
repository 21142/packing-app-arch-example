using Microsoft.EntityFrameworkCore;
using PackingApp.Application.DTO;
using PackingApp.Application.Queries;
using PackingApp.Infrastructure.Models;
using PackingApp.Infrastructure.Persistence;
using PackingApp.Shared.Abstractions.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace PackingApp.Infrastructure.QueryHandlers
{
    public class GetSuitcaseHandler : IQueryHandler<GetSuitcase, SuitcaseDto>
    {
        private readonly DbSet<SuitcaseReadModel> _suitcases;

        public GetSuitcaseHandler(ReadDbContext context)
            => _suitcases = context.Suitcases;

        public Task<SuitcaseDto> HandleAsync(GetSuitcase query)
            => _suitcases
                .Include(s => s.SuitcaseItems)
                .Where(s => s.Id == query.Id)
                .Select(s => s.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
    }
}
