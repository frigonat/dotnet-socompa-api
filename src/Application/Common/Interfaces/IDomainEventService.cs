using dotnet_socompa_api.Domain.Common;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
