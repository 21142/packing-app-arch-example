using PackingApp.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackingApp.Application.Services
{
    public interface ISuitcaseReadService
    {
        Task<bool> NameAlreadyExistsAsync(string name);
    }
}
