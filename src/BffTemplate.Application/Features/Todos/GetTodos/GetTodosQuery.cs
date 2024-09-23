using BffTemplate.Application.Abstractions.Messaging;
using BffTemplate.Application.Dtos;

namespace BffTemplate.Application.Features.Todos.GetTodos;

public record GetTodosQuery() : IQuery<GetTodosResult>;

public record GetTodosResult(IEnumerable<TodoDto> Todos);