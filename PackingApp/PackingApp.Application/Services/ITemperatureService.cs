using PackingApp.Application.DTO;
using PackingApp.Domain.ValueObjects;
using System.Threading.Tasks;

namespace PackingApp.Application.Services
{
    public interface ITemperatureService
    {
        Task<TemperatureDto> GetTemperatureAsync(Location location);
    }
}
