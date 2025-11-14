using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WebApiLabDevOps.Domain.Abstractions;

namespace WebApiLabDevOps.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<List<WeatherForecastModel>> ProcessFTemperaturesAsync()
        {
            var forecasts = await _weatherForecastRepository.GetForecastsAsync();

            var processed = new List<WeatherForecastModel>();
            foreach (var forecast in forecasts)
            {
                forecast.TemperatureF = 32 + (int)(forecast.TemperatureC / 0.5556);
                processed.Add(forecast);
            }

            return processed;
        }
    }
}
