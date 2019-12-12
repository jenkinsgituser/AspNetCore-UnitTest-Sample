using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.IntegrationTest
{
    public class WeatherTestStartup : Startup
    {
        public WeatherTestStartup(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
