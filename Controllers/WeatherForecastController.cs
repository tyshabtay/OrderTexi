//using Microsoft.AspNetCore.Mvc;
//using OrderTexi.Modals;
//using static System.Net.Mime.MediaTypeNames;

//namespace OrderTexi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };
        
//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
          
//            _logger = logger;
//        }

//        [HttpGet(Name = "GetWeatherForecast")]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            WeatherForecast[] w = new WeatherForecast[2];
//            return w;
//            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            //{
//            //    Date = DateTime.Now.AddDays(index),
//            //    TemperatureC = Random.Shared.Next(-20, 55),
//            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            //})
//            //.ToArray();
//        }
//    }
//}