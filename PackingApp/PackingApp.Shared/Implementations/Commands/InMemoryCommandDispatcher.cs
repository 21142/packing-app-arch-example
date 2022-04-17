using Microsoft.Extensions.DependencyInjection;
using PackingApp.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;

namespace PackingApp.Shared.Implementations.Commands
{
    public class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task DispatchAsyns<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            await handler.HandleAsync(command);
        }
    }
}
