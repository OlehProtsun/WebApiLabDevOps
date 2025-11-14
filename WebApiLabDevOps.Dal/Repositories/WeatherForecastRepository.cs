using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiLabDevOps.Domain.Abstractions;
using WebApiLabDevOps.Domain.Models.DataBaseContext;

namespace WebApiLabDevOps.Dal.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WetherForecastContext _context;

        public WeatherForecastRepository(WetherForecastContext context)
        {
            _context = context;
        }
        public async Task<WeatherForecastModel[]> GetForecastsAsync()
        {
            return await _context.WeatherForecasts
                                 .OrderBy(x => x.Date)
                                 .ToArrayAsync();
        }
    }
}
