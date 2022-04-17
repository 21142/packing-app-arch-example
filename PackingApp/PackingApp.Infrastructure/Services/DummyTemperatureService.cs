using PackingApp.Application.DTO;
using PackingApp.Application.Services;
using PackingApp.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PackingApp.Infrastructure.Services
{
    public class DummyTemperatureService : ITemperatureService
    {
        public Task<TemperatureDto> GetTemperatureAsync(Location location)
            => Task.FromResult(new TemperatureDto(new Random().Next(-10, 25)));
    }
}
