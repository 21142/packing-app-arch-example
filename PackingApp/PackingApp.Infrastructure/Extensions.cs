using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackingApp.Application.Services;
using PackingApp.Domain.Repositories;
using PackingApp.Infrastructure.Persistence;
using PackingApp.Infrastructure.Repositories;
using PackingApp.Infrastructure.Services;
using PackingApp.Shared.Implementations.Queries;

namespace PackingApp.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISuitcaseRepository, SuitcaseRepository>();
            services.AddScoped<ISuitcaseReadService, SuitcaseReadService>();
            
            services.AddDbContext<ReadDbContext>(c => c.UseSqlServer(@"Server=(localdb)\\RecruitmentTestDb;Database=Test"));
            services.AddDbContext<WriteDbContext>(c => c.UseSqlServer(@"Server=(localdb)\\RecruitmentTestDb;Database=Test"));
            services.AddQueries();
            services.AddSingleton<ITemperatureService, DummyTemperatureService>();

            return services;
        }
    }
}
