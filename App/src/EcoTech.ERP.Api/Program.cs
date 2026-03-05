using EcoTech.ERP.Api.App;
using EcoTech.ERP.Api.App.Exceptions;
using EcoTech.ERP.Api.App.Interfaces;
using EcoTech.ERP.Api.App.Services;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Queries;
using EcoTech.ERP.Enterprise.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Servicios
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'GamaMateriales'");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllUsuariosQuery).Assembly));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddAllServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://ecotech-erp-web.dev.localhost:7137", "http://ecotech-erp-web.dev.localhost:5062")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.MapControllers();
app.Endpoints();

app.Run();