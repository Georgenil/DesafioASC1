using DesafioASC.Application.UseCases.Reserva.Commands;
using DesafioASC.Application.UseCases.Reserva.Commands.Handlers;
using DesafioASC.Application.UseCases.Reserva.Queries;
using DesafioASC.Application.UseCases.Reserva.Queries.Handlers;
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
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configurando o banco.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionando repositories
builder.Services.AddScoped<ISalaRepository, SalaRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();


//builder.Services.AddHandlers();

builder.Services.AddScoped<IDispatcher, Dispatcher>();

//TODO Trocar pelo AddHandlers() depois;
builder.Services.AddScoped<ICommandHandler<CreateSalaCommand>, CreateSalaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateSalaCommand>, UpdateSalaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteSalaCommand>, DeleteSalaCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetSalaByIdQuery, Sala?>, GetSalaByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllSalaQuery, List<Sala>?>, GetAllSalaQueryHandler>();

builder.Services.AddScoped<ICommandHandler<CreateReservaCommand>, CreateReservaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateReservaCommand>, UpdateReservaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteReservaCommand>, DeleteReservaCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetReservaByIdQuery, Reserva?>, GetReservaByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllReservaQuery, List<Reserva>?>, GetAllReservaQueryHandler>();



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Minha API de Reservas",
        Description = "Sistema de Gestão de Reservas de Salas. Em .NET Core Web API .",
    });

    string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
    string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
    string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

    options.IncludeXmlComments(caminhoXmlDoc);
    // using System.Reflection;
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "Minha API de Reservas V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
