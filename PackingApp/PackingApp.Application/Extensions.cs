using Microsoft.Extensions.DependencyInjection;
using PackingApp.Domain.Factories;
using PackingApp.Domain.Policies;
using PackingApp.Shared.Implementations.Commands;

namespace PackingApp.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ISuitcaseFactory, SuitcaseFactory>();

            services.Scan(a => a.FromAssemblies(typeof(ISuitcaseItemsPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<ISuitcaseItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
