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
using dotnet_socompa_api.Application.UseCase.V1.PedidoOperation.Queries.GetByName;


namespace dotnet_socompa_api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class PedidoController : ApiControllerBase
{
    /// <summary>
    /// Alta de nuevo pedido.-
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreatePedidoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreatePedidoCommand body) => Result(await Mediator.Send(body));

    /// <summary>
    /// Listado de persona de la base de datos
    /// </summary>
    /// <remarks>en los remarks podemos documentar información más detallada</remarks>
    /// <returns></returns>
    //[HttpGet]
    //[ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListPerson()));

    //[HttpPut("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> Update(string id, UpdatePersonVm body)
    //{
    //    return Result(await Mediator.Send(new UpdatePersonCommand
    //    {
    //        PersonId = id,
    //        Apellido = body.Apellido,
    //        Nombre = body.Nombre
    //    }));
    //}

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        return Result(await Mediator.Send(new GetPedidoById() { id = id}));
    }
}


