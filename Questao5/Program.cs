using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Questao5.Infrastructure.Database;
using Microsoft.Data.Sqlite;
using System.Data; // Certifique-se de que o namespace está correto

var builder = WebApplication.CreateBuilder(args);

// Adicione o registro da conexão do banco de dados
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("A string de conexão não está definida.");
    }

    var connection = new SqliteConnection(connectionString);
    connection.Open(); // Abrindo a conexão
    return connection;
});

// Registre o repositório
builder.Services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();

// Configuração do MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

// Configuração do Swagger
builder.Services.AddSwaggerGen();

// Adicione serviços de controle de API
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Execução da aplicação
app.Run();
