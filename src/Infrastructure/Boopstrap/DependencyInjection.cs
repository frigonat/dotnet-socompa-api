using Andreani.Arq.Cqrs.Extension;
using Andreani.Arq.AMQStreams;
using Andreani.Scheme;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Infrastructure.Persistence;
using dotnet_socompa_api.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Andreani.Arq.AMQStreams.Extensions;
using Andreani.Scheme.Onboarding;

namespace dotnet_socompa_api.Infrastructure.Boopstrap;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS(configuration)
        .Configure<ApplicationDbContext>();

        services.AddKafka(configuration)
            .CreateOrUpdateTopic(6, "OnboardingBackendFernando-Andreani.Scheme.Onboarding.Pedido")
            .ToProducer<Pedido>("OnboardingBackendFernando-Andreani.Scheme.Onboarding.Pedido")
            .Build();

        services.AddScoped<ICommandSqlServer, CommandSqlServer>();
        services.AddScoped<IQuerySqlServer, QuerySqlServer>();
        return services;
    }
}
