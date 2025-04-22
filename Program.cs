using Microsoft.EntityFrameworkCore;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o CORS
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

// Configura��o do CORS
app.UseCors();

// For�ar o uso de HTTPS se necess�rio
app.UseHttpsRedirection();

// Autoriza��o
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

// Definir as portas HTTP e HTTPS explicitamente
app.Run("http://localhost:5000");  // HTTP
app.Run("https://localhost:5001"); // HTTPS
