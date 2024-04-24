using Andreani.Arq.Cqrs.Command;
using Andreani.Arq.Cqrs.Interfaces;
using dotnet_socompa_api.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace dotnet_socompa_api.Infrastructure.Services
{
    public class CommandSqlServer([FromKeyedServices("default")] ITransactionalConfiguration config) : TransactionalRepository(config), ICommandSqlServer
    {
    }
}
