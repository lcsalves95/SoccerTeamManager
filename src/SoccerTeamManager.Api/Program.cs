using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Infra.Data.Contexts;
using SoccerTeamManager.Infra.IoC.Exceptions;
using SoccerTeamManager.Infra.IoC.PipelineBehavior;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(typeof(GetPlayerQuery));
builder.Services.AddMediatR(typeof(InsertPlayerCommand));


builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddControllers();
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
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
