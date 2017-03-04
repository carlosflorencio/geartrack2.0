using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeartrackApi.Services;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Diagnostics;
using GeartrackApi.Controllers;

namespace GeartrackApiTest
{
    [TestClass]
    public class SkyTest
    {
        [TestMethod]
        public async Task PriorityLineTest()
        {
            var logger = new Mock<ILogger<HttpService>>().Object;
            var service = new HttpService(logger);
            var controller = new SkyController(service);

            var test = await controller.GetAsync("PQ4F6P0704104480181750Q");

            // TODO: Change this test to pass
            Assert.AreEqual("teste", test);
        }
    }
}
