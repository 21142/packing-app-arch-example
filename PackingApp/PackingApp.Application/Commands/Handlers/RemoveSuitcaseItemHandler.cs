using PackingApp.Application.Exceptions;
using PackingApp.Domain.Repositories;
using PackingApp.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;

namespace PackingApp.Application.Commands.Handlers
{
    public class RemoveSuitcaseItemHandler : ICommandHandler<RemoveSuitcaseItem>
    {
        private readonly ISuitcaseRepository _repository;

        public RemoveSuitcaseItemHandler(ISuitcaseRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemoveSuitcaseItem command)
        {
            var (id, name) = command;

            var suitcase = await _repository.GetAsync(id);

            if (suitcase is null)
            {
                throw new SuitcaseNotFoundException(id);
            }

            suitcase.RemoveSuitcaseItem(name);

            await _repository.UpdateAsync(suitcase);
        }
    }
}
