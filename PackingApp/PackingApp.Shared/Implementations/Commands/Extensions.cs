using Microsoft.Extensions.DependencyInjection;
using PackingApp.Shared.Abstractions.Commands;
using PackingApp.Shared.Implementations.Commands;
using System.Reflection;

namespace PackingApp.Shared.Implementations.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
