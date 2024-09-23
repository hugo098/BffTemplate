using BffTemplate.Application;
using BffTemplate.Infrastructure;
using BffTemplate.WebApi;
using BffTemplate.WebApi.Middlewares;
using Serilog;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

// Add services to the container
builder.Services
       .AddApplication(builder.Configuration)
       .AddInfrastructure(builder.Configuration)
       .AddApi(builder.Configuration);

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline
app.UseSerilogRequestLogging();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.UseExceptionHandler(options => { });

app.Run();
