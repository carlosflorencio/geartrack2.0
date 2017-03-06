using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeartrackApi.Services;
using Moq;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GeartrackApiTest
{
    [TestClass]
    public class HttpServiceTest
    {
        [TestMethod]
        public async Task Test_Get_Status_500()
        {
            var loggerHttp = new Mock<ILogger<HttpService>>().Object;
            var httpService = new HttpService(loggerHttp);

            try
            {
                var response = await httpService.GetAsync("https://httpbin.org/status/500");
                Assert.Fail();
            } catch(Exception)
            {

            }
        }

        [TestMethod]
        public async Task Test_Get_Timeout()
        {
            var loggerHttp = new Mock<ILogger<HttpService>>().Object;
            var httpService = new HttpService(loggerHttp);

            try
            {
                var response = await httpService.GetAsync("http://request.dev/?code=500&delay=10");
            }
            catch (Exception e)
            {
                Assert.AreEqual("teste", e.Message);
            }
        }
    }
}
