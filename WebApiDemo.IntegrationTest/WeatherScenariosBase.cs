using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace WebApiDemo.IntegrationTest
{
    public class WeatherScenariosBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(WeatherScenariosBase))
              .Location;
            var hostBuilder = new WebHostBuilder()
              .UseContentRoot(Path.GetDirectoryName(path))
              .ConfigureAppConfiguration(cb =>
              {
                  cb.AddJsonFile("appsettings.json", optional: false)
                  .AddEnvironmentVariables();
              }).UseStartup<Startup>();

            var testServer = new TestServer(hostBuilder);
            return testServer;
        }

        public static class Get
        {
            public static string GetList()
            {
                return $"weatherforecast";
            }
        }

    }
}
