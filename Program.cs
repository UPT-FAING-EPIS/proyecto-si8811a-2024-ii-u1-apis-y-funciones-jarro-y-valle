using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Models;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Services;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Config MongoDB
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Configurar servicios y controladores
builder.Services.AddControllers();

// Configurar el cliente MongoDB
builder.Services.AddSingleton<IMongoClient>(s =>
{
    var settings = s.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Agregar servicios específicos
builder.Services.AddSingleton<EventoService>();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Aplicar CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();


app.Run();
