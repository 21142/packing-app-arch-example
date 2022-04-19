using PackingApp.Application.Exceptions;
using PackingApp.Domain.Repositories;
using PackingApp.Domain.ValueObjects;
using PackingApp.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PackingApp.Application.Commands.Handlers
{
    public class AddSuitcaseItemHandler : ICommandHandler<AddSuitcaseItem>
    {
        private readonly ISuitcaseRepository _repository;

        public AddSuitcaseItemHandler(ISuitcaseRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddSuitcaseItem command)
        {
            var (id, name, quantity) = command;

            var suitcase = await _repository.GetAsync(id);

            if (suitcase is null)
            {
                throw new SuitcaseNotFoundException(id);
            }

            var suitcaseItem = new SuitcaseItem(name, quantity);
            suitcase.AddSuitcaseItem(suitcaseItem);

            await _repository.UpdateAsync(suitcase);
        }
    }
}
