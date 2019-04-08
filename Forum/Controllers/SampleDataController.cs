using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private ApplicationContext applicationContext;

        public SampleDataController(ApplicationContext ac)
        {
            applicationContext = ac;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            bool isFound = applicationContext.Posts.Find(1) != null;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = 100,
                Summary = Summaries[0],
                IsFound = isFound
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
            public bool IsFound { get; set; }
            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
