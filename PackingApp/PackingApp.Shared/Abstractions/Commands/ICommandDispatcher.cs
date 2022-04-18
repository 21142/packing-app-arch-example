using System.Threading.Tasks;

namespace PackingApp.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
