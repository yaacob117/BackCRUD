using PruebaCRUD.Contexts;
using PruebaCRUD.Models;
using PruebaCRUD.IRepository;
using PruebaCRUD.Repository;
using Microsoft.EntityFrameworkCore;
//using PruebaCRUD.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Contexto
//Cadena Conexión Appsetting.json
var configuration = builder.Configuration;
var Local = configuration.GetConnectionString("Local");

builder.Services.AddDbContext<LocalDBContext>(options => options.UseSqlServer(Local));
//  Interfaz vs repositorio

builder.Services.AddScoped<IAuthorsRepository, AuthorRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(options =>
{
options.WithOrigins("http://*");
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
