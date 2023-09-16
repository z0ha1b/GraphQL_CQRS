using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Scheduling.API.Extensions;
using Scheduling.GraphQL.Extensions;
using Scheduling.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddProjectsServices(configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scheduling.API", Version = "v1" }); });
builder.Services.AddHealthChecks().Services.AddDbContext<SchedulingContext>();

//graphQL
builder.Services.AddGraphQLServices();

var app = builder.Build();

app.MigrateDatabase<SchedulingContext>((context, services) =>
{
    var logger = services.GetService<ILogger<SchedulingContextSeed>>();
    if (logger is not null)
    {
        SchedulingContextSeed.SeedAsync(context, logger).Wait();
    }
});

// graphQL
app.ConfigureEndPoint();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scheduling.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();