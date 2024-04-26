using Andreani.Arq.Pipeline.Clases;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Queries.GetList
{
    public record struct ListPedido : IRequest<Response<List<Pedido>>>
    {
    }

    public class ListPedidoHandler(IQuerySqlServer query) : IRequestHandler<ListPedido, Response<List<Pedido>>>
    {
        public async Task<Response<List<Pedido>>> Handle(ListPedido request, CancellationToken cancellationToken)
        {
            //var result = await query.GetAllAsync<Pedido>();
            var result = await query.GetAllPedidosAsync();
            return new Response<List<Pedido>>
            {
                Content = result.ToList(),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
