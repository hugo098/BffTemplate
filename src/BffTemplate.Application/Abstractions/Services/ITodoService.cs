using BffTemplate.Domain.Models;

namespace BffTemplate.Application.Abstractions.Services;
public interface ITodoService
{
    public Task<IEnumerable<Todo>> GetTodosAsync();
}
