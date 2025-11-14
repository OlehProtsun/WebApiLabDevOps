using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiLabDevOps.Domain.Abstractions
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherForecastModel[]> GetForecastsAsync();
    }
}
