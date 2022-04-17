using PackingApp.Application.Exceptions;
using PackingApp.Application.Services;
using PackingApp.Domain.Factories;
using PackingApp.Domain.Repositories;
using PackingApp.Domain.ValueObjects;
using PackingApp.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PackingApp.Application.Commands.Handlers
{
    public class CreateSuitcaseWithItemsHandler : ICommandHandler<CreateSuitcaseWithItems>
    {
        private readonly ISuitcaseRepository _repository;
        private readonly ISuitcaseFactory _factory;
        private readonly ISuitcaseReadService _readService;
        private readonly ITemperatureService _temperatureService;

        public CreateSuitcaseWithItemsHandler(ISuitcaseRepository repository, ISuitcaseFactory factory, 
            ISuitcaseReadService readService, ITemperatureService temperatureService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
            _temperatureService = temperatureService;
        }

        public async Task HandleAsync(CreateSuitcaseWithItems command)
        {
            var (id, name, days, gender, locationWriteModel) = command;

            if (await _readService.NameAlreadyExistsAsync(name))
            {
                throw new SuitcaseAlreadyExistsException(command.Name);
            }

            var location = new Location(locationWriteModel.Country, locationWriteModel.City);
            var temperature = await _temperatureService.GetTemperatureAsync(location);

            if (temperature is null)
            {
                throw new MissingLocationTemperatureException(location);
            }

            var suitcase = _factory.CreateWithEssentialClothes(id, name, location, days, gender, temperature.Temperature);

            await _repository.AddAsync(suitcase);
        }
    }
}
