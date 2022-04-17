using PackingApp.Application.Exceptions;
using PackingApp.Domain.Repositories;
using PackingApp.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingApp.Application.Commands.Handlers
{
    public class DeleteSuitcaseHandler : ICommandHandler<DeleteSuitcase>
    {
        private readonly ISuitcaseRepository _repository;

        public DeleteSuitcaseHandler(ISuitcaseRepository repository)
            => _repository = repository;

        public async Task HandleAsync(DeleteSuitcase command)
        {
            var suitcase = await _repository.GetAsync(command.SuitcaseId);

            if (suitcase is null)
            {
                throw new SuitcaseNotFoundException(command.SuitcaseId);
            }

            await _repository.DeleteAsync(suitcase);
        }
    }
}
