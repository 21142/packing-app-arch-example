using Microsoft.EntityFrameworkCore;
using PackingApp.Domain.Entities;
using PackingApp.Domain.Repositories;
using PackingApp.Domain.ValueObjects;
using PackingApp.Infrastructure.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace PackingApp.Infrastructure.Repositories
{
    public class SuitcaseRepository : ISuitcaseRepository
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly DbSet<Suitcase> _suitcases;

        public SuitcaseRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _suitcases = writeDbContext.Suitcases;
        }

        public Task<Suitcase> GetAsync(SuitcaseId id)
            => _suitcases.Include("_clothes").SingleOrDefaultAsync(s => s.Id == id);

        public async Task AddAsync(Suitcase suitcase)
        {
            await _suitcases.AddAsync(suitcase);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Suitcase suitcase)
        {
            _suitcases.Remove(suitcase);
            await _writeDbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(Suitcase suitcase)
        {
            _suitcases.Update(suitcase);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
