using Andreani.Arq.Pipeline.Clases;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Domain.Entities;
using dotnet_socompa_api.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Commands.Create
{
    public class CreatePedidoCommand : IRequest<Response<CreatePedidoResponse>>
    {
        public required long codigoDeContratoInterno { get; set; }
        public required string cuentaCorriente { get; set; }
    }

    public class CreatePedidoCommandHandler(ICommandSqlServer repository, ILogger<CreatePedidoCommandHandler> logger) : IRequestHandler<CreatePedidoCommand, Response<CreatePedidoResponse>>
    {
        public async Task<Response<CreatePedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            Guid nuevoId = Guid.NewGuid();    
            var entity = new Pedido
            {
                id = nuevoId,
                numeroDePedido = null,
                cicloDelPedido = nuevoId.ToString(),
                codigoDeContratoInterno = request.codigoDeContratoInterno,
                estadoDelPedido = (int) EstadosDePedidos.Creado,
                cuentaCorriente = request.cuentaCorriente,
                cuando = DateTime.Now
            };

            repository.Insert(entity);
            await repository.SaveChangeAsync();

            logger.LogDebug("Se ha creado un pedido satisfactoriamente, con id {id}.", entity.id);

            return new Response<CreatePedidoResponse>
            {
                Content = new CreatePedidoResponse
                {
                    pedidoId = entity.id.ToString(),
                    message = "Pedido creado satisfactoriamente."
                },
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
    }
}
