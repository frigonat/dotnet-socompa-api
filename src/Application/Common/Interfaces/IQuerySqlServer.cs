using Andreani.Arq.Core.Interface;
using dotnet_socompa_api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.Common.Interfaces;

    public interface IQuerySqlServer: IReadOnlyQuery
    {
        public Task<Person> GetPersonByNameAsync(string name);

        public Task<Pedido> GetPedidoByIdAsync(Guid id);
    }
