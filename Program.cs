using LaGata.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LaGata.Api.Interfaces;
using LaGata.Api.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// 🔗 Configurar EF Core con Azure SQL
builder.Services.AddDbContext<LaGataDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🛡️ Registrar servicios personalizados
builder.Services.AddScoped<ISeguridadService, SeguridadService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IDetalleProductoService, DetalleProductoService>();

// 🌐 Configurar CORS para permitir peticiones desde Flutter
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 📦 Servicios base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "LaGata API", 
        Version = "v1",
        Description = "API para el sistema LaGata"
    });
});

var app = builder.Build();

// 🧱 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🧩 Activar CORS
app.UseCors("AllowAll");

app.UseAuthorization(); // Si luego agregas JWT

app.MapControllers(); // Activar tus controladores personalizados

app.Run();