using HiLoGuessing.Application.Services.Interfaces;
using HiLoGuessing.Application.Services;
using HiLoGuessing.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register your services with the interfaces here
builder.Services.AddSingleton<IMysteryNumberService, MysteryNumberService>();
builder.Services.AddSingleton<IAttemptsService, AttemptsService>();
builder.Services.AddSingleton<IComparisonService, ComparisonService>();

builder.Services.AddInfrastructure();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
