using BffTemplate.Application.Abstractions.Services;
using BffTemplate.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace BffTemplate.Infrastructure.Services;
public class TodoService(HttpClient httpClient, ILogger<TodoService> logger): ITodoService
{
    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        logger.LogInformation("Fetching Todos from JSONPlaceholder");

        try
        {
            HttpResponseMessage response = await httpClient
                .GetAsync("/todos")
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            IEnumerable<Todo>? todos = await response.Content
                .ReadFromJsonAsync<IEnumerable<Todo>>()
                .ConfigureAwait(false);

            return todos ?? [];
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "Error fetching Todos");
            throw;
        }
    }
}
