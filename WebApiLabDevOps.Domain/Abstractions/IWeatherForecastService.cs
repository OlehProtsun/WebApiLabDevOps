using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiLabDevOps.Domain.Abstractions
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecastModel>> ProcessFTemperaturesAsync();
    }
}
