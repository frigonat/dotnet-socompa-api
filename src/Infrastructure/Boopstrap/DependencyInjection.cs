using Andreani.Arq.Cqrs.Extension;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Infrastructure.Persistence;
using dotnet_socompa_api.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_socompa_api.Infrastructure.Boopstrap;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS(configuration)
        .Configure<ApplicationDbContext>();

        services.AddScoped<ICommandSqlServer, CommandSqlServer>();
        services.AddScoped<IQuerySqlServer, QuerySqlServer>();

    return services;
    }
}
