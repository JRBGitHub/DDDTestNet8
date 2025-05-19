using DDDTestNet8.Domain;
using DDDTestNet8.Application;
using DDDTestNet8.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Simulación de base de datos en memoria
var db = new List<AcumuladoDivisa>
{
    new AcumuladoDivisa { IdHost = 1, Canal = "WEB1", AcumuladoDiario = 100, AcumuladoSemanal = 500, AcumuladoMensual = 2000 },
    new AcumuladoDivisa { IdHost = 1, Canal = "APP2", AcumuladoDiario = 50, AcumuladoSemanal = 200, AcumuladoMensual = 800 },
    new AcumuladoDivisa { IdHost = 2, Canal = "WEB1", AcumuladoDiario = 20, AcumuladoSemanal = 100, AcumuladoMensual = 400 },
    // Puedes agregar más datos de ejemplo aquí
};

builder.Services.AddSingleton<IAcumuladoDivisaRepository>(new AcumuladoDivisaInMemoryRepository(db));
builder.Services.AddSingleton<IAcumuladoDivisaService, AcumuladoDivisaService>();


var app = builder.Build();

// Habilitar Swagger siempre y redirigir a /swagger al iniciar
app.UseSwagger();
app.UseSwaggerUI();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.UseHttpsRedirection();

// Endpoint principal para consulta de acumulados
app.MapGet("/acumulados", (int idhost, string? canal, IAcumuladoDivisaService service) =>
{
    var result = service.GetAcumulados(idhost, canal);
    return Results.Ok(result);
});

app.Run();
