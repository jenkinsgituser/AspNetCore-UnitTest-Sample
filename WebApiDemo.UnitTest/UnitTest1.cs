using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Controllers;
using WebApiDemo.Services;
using Xunit;

namespace WebApiDemo.UnitTest
{
    public class UnitTest1
    {
        private readonly Mock<IWeatherForecastService> _serviceMock;
        private readonly Mock<ILogger<WeatherForecastController>> _loggerMock; 
        public UnitTest1()
        {
            _serviceMock = new Mock<IWeatherForecastService>();
            _loggerMock = new Mock<ILogger<WeatherForecastController>>();
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<WeatherForecast> GetList()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Fact]
        public void Test1()
        {
            //use mock to setup desired response
            _serviceMock.Setup(x => x.GetList()).Returns(GetList());

            var controller = new WeatherForecastController(_loggerMock.Object, _serviceMock.Object);
            var actionResult = controller.Get();
            Assert.NotNull(actionResult);
            Assert.True(actionResult.Count() == 5);
        }
    }
}
