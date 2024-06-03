using Andreani.Arq.AMQStreams.Interface;
using Andreani.Arq.Pipeline.Clases;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Commands.Create;
using dotnet_socompa_api.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Commands.Publish
{
    public class PublishPedidoCommand : IRequest<Response<PublishPedidoResponse>>
    {
        public required Pedido pedidoParaPublicar { get; set; }
    }

    public class PublishPedidoCommandHandler(ICommandSqlServer repository, ILogger<CreatePedidoCommandHandler> logger, Andreani.Arq.AMQStreams.Interface.IPublisher publisher) : IRequestHandler<PublishPedidoCommand, Response<PublishPedidoResponse>>
    {
        public async Task<Response<PublishPedidoResponse>> Handle(PublishPedidoCommand request, CancellationToken cancellationToken)
        {
            Andreani.Scheme.Onboarding.Pedido p = new Andreani.Scheme.Onboarding.Pedido()
            {
                id = request.pedidoParaPublicar.id.ToString(),
                codigoDeContratoInterno = request.pedidoParaPublicar.codigoDeContratoInterno,
                cuando = request.pedidoParaPublicar.cuando.ToString(),
                estadoDelPedido = request.pedidoParaPublicar.estadoDelPedido.ToString(),
                numeroDePedido = 0,
                cuentaCorriente = System.Convert.ToInt64(request.pedidoParaPublicar.cuentaCorriente),
                cicloDelPedido = request.pedidoParaPublicar.cicloDelPedido
            };

            await publisher.To(p, "OnboardingBackendFernando-Andreani.Scheme.Onboarding.Pedido");

            return new Response<PublishPedidoResponse>
            {
                Content = new PublishPedidoResponse
                {
                    pedidoId = request.pedidoParaPublicar.id,
                    message = "Pedido publicado satisfactoriamente.-"
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }

}
