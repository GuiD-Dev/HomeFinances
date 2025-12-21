using GastosResidenciais.WebApi.API.Interfaces;
using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Application.Services;
using GastosResidenciais.WebApi.Infra.Contexts;
using GastosResidenciais.WebApi.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddDbContext<PgSqlDbContext>(options =>
    options.UseNpgsql(builder.Configuration["PgSQlConnection:PgSQlConnectionString"])
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
