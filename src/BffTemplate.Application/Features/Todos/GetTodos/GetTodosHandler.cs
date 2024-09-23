using BffTemplate.Application.Abstractions.Messaging;
using BffTemplate.Application.Abstractions.Services;
using BffTemplate.Application.Extensions;
using BffTemplate.Domain.Models;

namespace BffTemplate.Application.Features.Todos.GetTodos;
public class GetTodosHandler(ITodoService todoService) : IQueryHandler<GetTodosQuery, GetTodosResult>
{
    public async Task<GetTodosResult> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Todo> todos = await todoService
            .GetTodosAsync()
            .ConfigureAwait(false);

        return new GetTodosResult(todos.ToTodoDtoList());
    }
}
