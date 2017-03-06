using Cimpress.Extensions.Http;
using Cimpress.Extensions.Http.MessageHandlers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeartrackApi.Services
{
    // This service is inject through DI with Singleton lifetime
    // This ensures one HttpClient for the app lifetime
    // Because of this https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    public class HttpService : IHttpService
    {
        private ILogger<HttpService> _logger;
        private HttpClient _httpClient;

        public HttpService(ILogger<HttpService> logger)
        {
            _logger = logger;

            // Adds logging to external requests
            var handler = new RetryHandler(new MeasurementHandler(_logger), 2);
            _httpClient = new HttpClient(handler);
            //_httpClient.Timeout = TimeSpan.FromSeconds(35);
        }

        public async Task<string> GetAsync(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            await response.LogAndThrowIfNotSuccessStatusCode(_logger);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
