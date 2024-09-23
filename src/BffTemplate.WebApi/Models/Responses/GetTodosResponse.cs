using BffTemplate.Application.Dtos;

namespace BffTemplate.WebApi.Models.Responses;
public record GetTodosResponse(IEnumerable<TodoDto> Todos);
