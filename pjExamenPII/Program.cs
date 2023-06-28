using Microsoft.EntityFrameworkCore;
using pjExamenPII;
using pjExamenPII.Data;
using pjExamenPII.RepostoryF;
using pjExamenPII.RepostoryF.IRepositoryF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FacturaContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("AvocadoConnection"));
});

builder.Services.AddScoped<IClientesRepositoy, ClienteRepository>();
builder.Services.AddScoped<IProductosRepository, ProductoRepository>();
builder.Services.AddScoped<IFacturasRepository, FacturaRepository>();
builder.Services.AddScoped<IDetallesFacturaRepository, DetalleFacturaRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
