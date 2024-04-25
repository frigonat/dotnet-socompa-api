using Andreani.Arq.Cqrs.Interfaces;
using Andreani.Arq.Cqrs.Queries;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dotnet_socompa_api.Infrastructure.Persistence;
using System.Threading.Tasks;
using System;

namespace dotnet_socompa_api.Infrastructure.Services
{
    public class QuerySqlServer : ReadOnlyQuery, IQuerySqlServer
    {
        private readonly ApplicationDbContext _context;
        public QuerySqlServer([FromKeyedServices("default")] IReadOnlyQueryConfiguration config,
            [FromKeyedServices("default")] ApplicationDbContext context) : base(config)
        {
          _context = context;
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
          return await _context.Person.FirstAsync(x => x.Nombre == name);
        }

        public async Task<Pedido> GetPedidoByIdAsync(Guid id)
        {
            return await _context.Pedido.FirstAsync(x => x.id == id);
        }
    }
}
