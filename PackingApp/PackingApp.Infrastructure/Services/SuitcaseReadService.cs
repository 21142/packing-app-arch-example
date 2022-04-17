using Microsoft.EntityFrameworkCore;
using PackingApp.Application.Services;
using PackingApp.Infrastructure.Models;
using PackingApp.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace PackingApp.Infrastructure.Services
{
    public class SuitcaseReadService : ISuitcaseReadService
    {
        private readonly DbSet<SuitcaseReadModel> _suitcases;

        public SuitcaseReadService(ReadDbContext context)
            => _suitcases = context.Suitcases;
        public Task<bool> NameAlreadyExistsAsync(string name)
            => _suitcases.AnyAsync(s => s.Name == name);
    }
}
