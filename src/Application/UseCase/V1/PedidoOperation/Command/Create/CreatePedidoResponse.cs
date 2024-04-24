using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Command.Create
{
    public record struct CreatePedidoResponse(int pedidoId, string message) { }
}
