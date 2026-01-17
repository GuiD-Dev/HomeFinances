using HomeFinances.WebApi.CrossCutting;
using HomeFinances.WebApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    );
});

builder.Services.AddControllers();

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Garantir que as migrations sejam aplicadas automaticamente ao iniciar a aplicação.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PgSqlDbContext>();
    db.Database.Migrate();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
