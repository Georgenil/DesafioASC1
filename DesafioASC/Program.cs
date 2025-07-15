using DesafioASC.Application.UseCases.Sala.Commands;
using DesafioASC.Application.UseCases.Sala.Commands.Handlers;
using DesafioASC.Application.UseCases.Sala.Queries;
using DesafioASC.Application.UseCases.Sala.Queries.Handlers;
using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence;
using DesafioASC.Persistence.Context;
using DesafioASC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configurando o banco.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionando repositories
builder.Services.AddScoped<ISalaRepository, SalaRepository>();


//builder.Services.AddHandlers();

builder.Services.AddScoped<IDispatcher, Dispatcher>();

//TODO Trocar pelo AddHandlers() depois;
builder.Services.AddScoped<ICommandHandler<CreateSalaCommand>, CreateSalaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateSalaCommand>, UpdateSalaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteSalaCommand>, DeleteSalaCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetSalaByIdQuery, Sala?>, GetSalaByIdQueryHandler>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DesafioASC API",
        Description = "Sistema de Gestão de Reservas de Salas. Em .NET Core Web API .",
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
