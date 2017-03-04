using GeartrackApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeartrackApi.Controllers
{
    [Route("api/sky")]
    public class SkyController : Controller
    {
        private const string url = "http://www.sky56.cn/track/track/result?tracking_number={0}";
        private IHttpService _http;

        public SkyController(IHttpService http)
        {
            _http = http;
        }

        // GET api/sky/id
        [HttpGet("{id}")]
        public async Task<string> GetAsync(string id)
        {
            var uri = string.Format(url, "PQ4F6P0704104480181750Q");

            var content = await _http.Get(uri);

            return content;
        }
    }
}