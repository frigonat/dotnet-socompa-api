using Andreani.Arq.Pipeline.Clases;
using Andreani.Arq.WebHost.Controllers;
using dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dotnet_socompa_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Queries.GetById;
using dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Queries.GetList;
using dotnet_socompa_api.Infrastructure.Services;
using dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Commands.Publish;


namespace dotnet_socompa_api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class PedidoController : ApiControllerBase
{
    /// <summary>
    /// Alta de nuevo pedido.-
    /// </summary>
    /// <param name="body">Datos contrato y cuenta corriente para el nuevo pedido.-</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreatePedidoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreatePedidoCommand body)
    {
        Response<CreatePedidoResponse> response = await Mediator.Send(body);
        Response<Pedido> miPedido =  await Mediator.Send(new GetPedidoById() { id = response.Content.pedidoId });

        await Mediator.Send( new PublishPedidoCommand() { pedidoParaPublicar = miPedido.Content } );

        return Result(response);
    }

    /// <summary>
    /// Listado de pedidos existentes.-
    /// </summary>
    /// <remarks>en los remarks podemos documentar información más detallada</remarks>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Pedido>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListPedido()));

    /// <summary>
    /// Búsqueda de un pedido según su Id.-
    /// </summary>
    /// <param name="id">Guid del pedido a buscar.-</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        return Result(await Mediator.Send(new GetPedidoById() { id = id}));
    }
}


