using Andreani.Arq.Pipeline.Clases;
using dotnet_socompa_api.Application.Common.Interfaces;
using dotnet_socompa_api.Application.UseCase.V1.PersonOperation.Commands.Create;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Command.Create
{
    public class CreatePedidoCommand : IRequest<Response<CreatePedidoResponse>>
    {

    }


    public class CreatePedidoCommandHandler(ICommandSqlServer repository, ILogger<CreatePersonCommandHandler> logger))

}
