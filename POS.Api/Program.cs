using POS.Application.Extensions;
using POS.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Configuracion para Injeccion de Dependecnia ==== INICIO
var configuration = builder.Configuration;

//CORS
var Cors = "Cors";

builder.Services.AddInjectionInfraestructure(configuration);
// Configuracion para Injeccion de Dependecnia ==== FIN
builder.Services.AddInjectionApplication(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: Cors, builder =>
    {
        builder.WithOrigins("*");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();
//Cors
app.UseCors(Cors);

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

public partial class Program { }