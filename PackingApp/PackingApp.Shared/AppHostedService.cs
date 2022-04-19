using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PackingApp.Shared
{
    public class AppHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AppHostedService(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContexts = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(c => c.GetTypes())
                .Where(c => typeof(DbContext).IsAssignableFrom(c) && c != typeof(DbContext) && !c.IsInterface);

            using var scope = _serviceProvider.CreateScope();
            foreach (var context in dbContexts)
            {
                var dbContext = scope.ServiceProvider.GetRequiredService(context) as DbContext;

                if (dbContext is null)
                {
                    continue;
                }

                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
