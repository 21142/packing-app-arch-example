using PackingApp.Domain.Entities;
using PackingApp.Domain.ValueObjects;
using System.Threading.Tasks;

namespace PackingApp.Domain.Repositories
{
    public interface ISuitcaseRepository
    {
        Task<Suitcase> GetAsync(SuitcaseId id);
        Task AddAsync(Suitcase suitcase);
        Task UpdateAsync(Suitcase suitcase);
        Task DeleteAsync(Suitcase suitcase);
    }
}
