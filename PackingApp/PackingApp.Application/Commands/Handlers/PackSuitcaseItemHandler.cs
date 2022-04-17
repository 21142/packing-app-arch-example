using PackingApp.Application.Exceptions;
using PackingApp.Domain.Repositories;
using PackingApp.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PackingApp.Application.Commands.Handlers
{
    public class PackSuitcaseItemHandler : ICommandHandler<PackSuitcaseItem>
    {
        private readonly ISuitcaseRepository _repository;

        public PackSuitcaseItemHandler(ISuitcaseRepository repository)
            => _repository = repository;

        public async Task HandleAsync(PackSuitcaseItem command)
        {
            var (id, name) = command;

            var suitcase = await _repository.GetAsync(id);

            if (suitcase is null)
            {
                throw new SuitcaseNotFoundException(id);
            }

            suitcase.PackSuitcaseItem(name);

            await _repository.UpdateAsync(suitcase);
        }
    }
}