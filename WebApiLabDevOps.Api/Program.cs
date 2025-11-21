using WebApiLabDevOps.Dal.EntitiFramework;
using WebApiLabDevOps.Dal.Repositories;
using WebApiLabDevOps.Domain.Abstractions;
using WebApiLabDevOps.Domain.Models.DataBaseContext;
using WebApiLabDevOps.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

DatabaseInitializer.EnsureDatabaseCreatedAndSeeded(app.Services);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/openapi/v1.json", "Open Api V1");
    });
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
