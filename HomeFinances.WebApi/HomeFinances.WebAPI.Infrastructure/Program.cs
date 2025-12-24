using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Application.Services;
using HomeFinances.WebApi.Infrastructure.Contexts;
using HomeFinances.WebApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    );
});

builder.Services.AddControllers();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddDbContext<PgSqlDbContext>(options =>
    options.UseNpgsql(builder.Configuration["PgSQlConnection:PgSQlConnectionString"])
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
