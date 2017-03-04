using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeartrackApi.Services;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Diagnostics;
using GeartrackApi.Controllers;
using GeartrackApi;

namespace GeartrackApiTest
{
    [TestClass]
    public class SkyTest
    {
        [TestMethod]
        public async Task PriorityLineTest()
        {
            var loggerApi = new Mock<ILogger<ApiController>>().Object;
            var loggerHttp = new Mock<ILogger<HttpService>>().Object;
            var httpService = new HttpService(loggerHttp);
            var providers = new GeartrackProviders(httpService);

            var controller = new ApiController(providers, loggerApi);

            var test = await controller.ParseProvider("sky", "PQ4F6P0704104480181750Q");

            // TODO: Change this test to pass
            Assert.AreEqual("teste", test);
        }
    }
}
