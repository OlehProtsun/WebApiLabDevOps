using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiLabDevOps.Dal.EntityFramework;

namespace WebApiLabDevOps.Dal.EntitiFramework
{
    public static class DatabaseInitializer
    {
        public static void EnsureDatabaseCreatedAndSeeded(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<WetherForecastContext>();

            // Створює БД і таблиці, якщо їх ще немає
            db.Database.EnsureCreated();

            // Якщо таблиця порожня – насіваємо 10 записів
            if (!db.WeatherForecasts.Any())
            {
                var random = new Random();
                var startDate = DateOnly.FromDateTime(DateTime.UtcNow.Date);

                var items = Enumerable.Range(1, 10)
                    .Select(i =>
                    {
                        var tempC = random.Next(-20, 35);
                        var tempF = (int)(tempC * 9.0 / 5.0 + 32);

                        return new WeatherForecastModel
                        {
                            Date = startDate.AddDays(i),
                            TemperatureC = tempC,
                            TemperatureF = tempF,
                            Summary = $"Sample record #{i}"
                        };
                    })
                    .ToList();

                db.WeatherForecasts.AddRange(items);
                db.SaveChanges();
            }
        }
    }
}
