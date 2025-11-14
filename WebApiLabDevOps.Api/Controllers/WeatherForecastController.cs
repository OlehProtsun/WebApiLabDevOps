using Microsoft.AspNetCore.Mvc;
using WebApiLabDevOps.Domain.Abstractions;

namespace WebApiLabDevOps.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastModel>> Get()
        {
            var result = await _weatherForecastService.ProcessFTemperaturesAsync();
            return result;
        }
    }
}
