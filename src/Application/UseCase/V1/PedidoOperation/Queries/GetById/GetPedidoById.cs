using Andreani.Arq.Pipeline.Clases;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Domain.Common;
using dotnet_socompa_api.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Queries.GetById
{
    public class GetPedidoById : IRequest<Response<Pedido>>
    {
        public required string id { get; set; }
    }

    public class GetPedidoByIdHandler(IQuerySqlServer query) : IRequestHandler<GetPedidoById, Response<Pedido>>
    {
        
        public async Task<Response<Pedido>> Handle(GetPedidoById request, CancellationToken cancellationToken)
        {
            var response = new Response<Pedido>();

            if (Guid.TryParse(request.id, out Guid resultado))
            {
                var pedido = await query.GetPedidoByIdAsync(resultado);
                if (pedido == null)
                {
                    response.AddNotification("#6031-i", nameof(request.id), string.Format(ErrorMessage.NOT_FOUND_RECORD, nameof(Pedido), request.id));
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return response;
                }

                response.Content = pedido;
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }
            else
            {
                response.AddNotification("#6031-ii", nameof(request.id), string.Format(ErrorMessage.ID_INVALIDO, nameof(Pedido), request.id));
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }
        }
    }
}