using BffTemplate.Application.Dtos;
using BffTemplate.Application.Features.Todos.GetTodos;
using BffTemplate.WebApi.Models.Responses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BffTemplate.WebApi.Controllers.v1;

[Route("api/todos")]
[ApiController]
public class TodosController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodos()
    {
        GetTodosQuery query = new();

        GetTodosResult result = await sender
            .Send(query)
            .ConfigureAwait(false);

        GetTodosResponse response = result.Adapt<GetTodosResponse>();

       return Ok(response);
    }
}
