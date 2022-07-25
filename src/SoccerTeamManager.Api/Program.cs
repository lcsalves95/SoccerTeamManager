using Confluent.Kafka;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data;
using SoccerTeamManager.Infra.Data.Contexts;
using SoccerTeamManager.Infra.Data.Repositories;
using SoccerTeamManager.Infra.PipelineBehavior;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITransferRepository, TransferRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(SoccerTeamManager.Application.AssemblyReference).Assembly);
builder.Services.AddMediatR(typeof(SoccerTeamManager.Domain.AssemblyReference).Assembly);

builder.Services.Scan(scan => scan.FromApplicationDependencies()
    .AddClasses(@class => @class.AssignableTo(typeof(IShallowValidator<>))).AsImplementedInterfaces())
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ShallowValidationBehavior<,>));

builder.Services.Scan(scan => scan.FromApplicationDependencies()
    .AddClasses(@class => @class.AssignableTo(typeof(IDeepValidator<>))).AsImplementedInterfaces())
    .AddTransient(typeof(IPipelineBehavior<,>), typeof(DeepValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(SoccerTeamManager.Domain.AssemblyReference).Assembly);

builder.Services.AddSingleton(new ProducerBuilder<string, string>(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("bootstrap.servers", builder.Configuration.GetConnectionString("Kafka"))
            }));

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Soccer Team Manager",
        Version = "v1",
        Description = "RESTFul API to practice REST maturity.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Lucas Alves",
            Email = "l.alves1995@outlook.com",
            Url = new Uri("https://www.linkedin.com/in/lucas-alves-b9b63b1b1")
        }
    });
    c.UseInlineDefinitionsForEnums();
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
