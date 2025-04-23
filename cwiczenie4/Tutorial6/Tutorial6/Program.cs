using Tutorial6.Configurations;
using Tutorial6.Repositories;
using Tutorial6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Dodaje kontrolery do buildera
builder.Services.AddControllers();

builder.Services.AddSingleton<IAnimalService, AnimalServiceImpl>();
builder.Services.AddSingleton<IAnimalRepository, AnimalRepositoryImpl>();
builder.Services.AddSingleton<IVisitService, VisitServiceImpl>();
builder.Services.AddSingleton<IVisitRepository, VisitRepositoryImpl>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// 2. Mapuje wszystkie końcówki z kontrolerów
app.MapControllers();

app.Run();