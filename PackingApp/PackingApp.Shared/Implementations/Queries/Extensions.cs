using Microsoft.Extensions.DependencyInjection;
using PackingApp.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PackingApp.Shared.Implementations.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
