using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
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
        private readonly ApplicationContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            CheckModelConfiguration();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        private void CheckModelConfiguration()
        {
            var model = _context.Model;

            foreach (var entityType in model.GetEntityTypes())
            {
                Console.WriteLine($"Entity: {entityType.Name}");
                foreach (var property in entityType.GetProperties())
                {
                    Console.WriteLine($"  Property: {property.Name}, Type: {property.ClrType.Name}");
                }
            }
        }
    }
}
