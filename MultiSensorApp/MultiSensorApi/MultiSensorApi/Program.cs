using MultiSensorApi.Models;
using MultiSensorApi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

/// <summary>
/// MongoDb Connection String intialization
/// Adds Services to the container
/// </summary>

builder.Services.Configure<SensorReadingsDatabaseSettings>(
    builder.Configuration.GetSection("SensorReadingsDatabase"));

builder.Services.AddSingleton<SensorReadingsService>();

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
