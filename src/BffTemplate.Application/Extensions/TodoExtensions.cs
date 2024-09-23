using BffTemplate.Application.Dtos;
using BffTemplate.Domain.Models;

namespace BffTemplate.Application.Extensions;
public static class TodoExtensions
{
    public static IEnumerable<TodoDto> ToTodoDtoList(this IEnumerable<Todo> todos)
    {
        return todos.Select(todo => new TodoDto(
           UserId: todo.UserId,
           Id: todo.Id,
           Title: todo.Title,
           Completed: todo.Completed           
       ));
    }
}
