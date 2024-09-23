using System.Diagnostics;

namespace BffTemplate.WebApi.Middlewares;

public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        Stopwatch timer = new();
        timer.Start();

        try
        {
            ArgumentNullException.ThrowIfNull(context);

            logger.LogInformation("[START] Request {Method} {Path} started",
                context.Request.Method,
                context.Request.Path);

            await next(context).ConfigureAwait(false);
        }
        finally
        {
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;

            if (timeTaken.Seconds > 3)
                logger.LogWarning("[PERFORMANCE] The request {Path} took {TimeTaken} seconds",
                    context.Request.Path, timeTaken.Seconds);

            logger.LogInformation("[END] Request {Method} {Path} completed in {ElapsedMilliseconds}ms with status code {StatusCode}",
                context.Request.Method,
                context.Request.Path,
                timeTaken.TotalMilliseconds,
                context.Response.StatusCode);            
        }
    }
}
