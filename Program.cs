using Microsoft.EntityFrameworkCore;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Usar Swagger para documentar a API
app.UseSwagger();
app.UseSwaggerUI();

// Configuração do CORS
app.UseCors();

// Forçar o uso de HTTPS se necessário
app.UseHttpsRedirection();

// Autorização
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

// Definir as portas HTTP e HTTPS explicitamente
app.Run("http://localhost:5000");  // HTTP
app.Run("https://localhost:5001"); // HTTPS
