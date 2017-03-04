using Cimpress.Extensions.Http.MessageHandlers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeartrackApi.Services
{
    // This service is inject through DI with Scoped lifetime
    // This ensures one HttpClient per request
    // According to https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    // We should use a single instance only, maybe we should
    public class HttpService : IHttpService
    {
        private ILogger<HttpService> _logger;
        private HttpClient _httpClient;

        public HttpService(ILogger<HttpService> logger)
        {
            _logger = logger;

            // Adds logging to external requests
            var handler = new MeasurementHandler(_logger);
            _httpClient = new HttpClient(handler);
        }

        public async Task<string> Get(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
