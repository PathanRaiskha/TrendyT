using Microsoft.AspNetCore.Mvc;
using TrendyT.DTO;
using TrendyT.Services.Interfaces;

namespace TrendyT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        "Freezing1", "Bracing1", "Chilly1", "Cool1", "Mild1", "Warm1", "Balmy1", "Hot1", "Sweltering1", "Scorching1",
        "Freezing11", "Bracing11", "Chilly11", "Cool11", "Mild11", "Warm11", "Balmy11", "Hot11", "Sweltering11", "Scorching11",
        "Freezing111", "Bracing111", "Chilly111", "Cool111", "Mild111", "Warm111", "Balmy111", "Hot111", "Sweltering111", "Scorching111"

    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService )
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            _userService.AddUser(new UserDTO()
            {
                FirstName = "AA1",
                LastName = "Al",
                Email = "apathanrr712@hmail.com",
                Password = "Password",
                Gender = true,
                Address = new AddressDTO()
                {
                    Street="XStreet",
                    City= "XCity",
                    District= "XDistrict",
                    State= "Xstate",
                    PostalCode= "XPostalCode"
                }
            });

            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}