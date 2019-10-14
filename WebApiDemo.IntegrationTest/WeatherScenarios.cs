using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using WebApiDemo.IntegrationTest;
using Xunit;

namespace WebApiDemo.FuncTest
{
    public class WeatherScenarios : WeatherScenariosBase
    {
        [Fact]
        public async Task Get_List_Return_Ok()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.GetList());

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
