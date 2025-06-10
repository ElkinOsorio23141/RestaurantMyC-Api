using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestaurantMyC_Api;
using RestaurantMyC_Api.Services.Categorias;
using RestaurantMyC_Api.Services.Clientes;
using RestaurantMyC_Api.Services.Mesas;
using RestaurantMyC_Api.Services.Pedidos;
using RestaurantMyC_Api.Services.Platos;
using RestaurantMyC_Api.Services.Reservas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IPedidosService, PedidosService>();
builder.Services.AddScoped<IPlatosService, PlatosService>();
builder.Services.AddScoped<IReservasService, ReservasService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar la cadena de conexion a nuestra clase de servicio en donde
//incluimos el contexto de datos que contiene información de la base de datos
builder.Services.AddDbContext<RestauratMyCContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
