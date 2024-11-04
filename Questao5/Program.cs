using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Questao5.Infrastructure.Database;
using Microsoft.Data.Sqlite;
using System.Data; // Certifique-se de que o namespace est� correto

var builder = WebApplication.CreateBuilder(args);

// Adicione o registro da conex�o do banco de dados
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("A string de conex�o n�o est� definida.");
    }

    var connection = new SqliteConnection(connectionString);
    connection.Open(); // Abrindo a conex�o
    return connection;
});

// Registre o reposit�rio
builder.Services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();

// Configura��o do MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

// Configura��o do Swagger
builder.Services.AddSwaggerGen();

// Adicione servi�os de controle de API
builder.Services.AddControllers();

var app = builder.Build();

// Configura��o do Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Execu��o da aplica��o
app.Run();
