using System.Threading.Tasks;

namespace PackingApp.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsyns<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
