using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetDeskApp.Data.Context;

namespace PetDeskApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly PetDeskContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, PetDeskContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            var appointments = await _dbContext.Appointments
                .Include(x => x.User)
                .Include(x => x.Animal)
                .AsNoTracking()
                .ToListAsync();
            return Ok(appointments);
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}