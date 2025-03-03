using Microsoft.EntityFrameworkCore;
using MoneyControl.Api.Filters;
using MoneyControl.Application;
using MoneyControl.Domain.Repository.Expenses;
using MoneyControl.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

// Ambiente local
var localConnectionStringName = "Connection";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

// Ambiente de homologação
//var developConnectionStringName = "Connection";

// Ambiente de produção
//var productionConnectionStringName = "Connection";

builder.Services.AddInfraestructure(builder.Configuration, localConnectionStringName, serverVersion);
builder.Services.AddApplication();


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

