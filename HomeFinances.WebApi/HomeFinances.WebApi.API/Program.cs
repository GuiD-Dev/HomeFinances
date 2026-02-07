using HomeFinances.WebApi.CrossCutting;
using HomeFinances.WebApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
    policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
  );
});

builder.Services.AddControllers();

builder.Services.AddDependencies(builder.Configuration);

var oTelBuilder = builder.Services.AddOpenTelemetry();

oTelBuilder.ConfigureResource(resource => resource.AddService(builder.Environment.ApplicationName))
  .WithTracing(tracing => tracing
    .AddAspNetCoreInstrumentation()
    .AddNpgsql()
    .AddOtlpExporter()
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<PgSqlDbContext>();
  db.Database.Migrate();
}

app.UseCors();
app.MapControllers();

app.Run();
