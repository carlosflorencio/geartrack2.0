using GeartrackApi.Exceptions;
using GeartrackApi.Models;
using GeartrackApi.Providers;
using GeartrackApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeartrackApi.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        private GeartrackProviders _providers;
        private ILogger<ApiController> _logger;

        public ApiController(GeartrackProviders providers, ILogger<ApiController> logger)
        {
            _logger = logger;
            _providers = providers;
        }

        // GET api/{provider}/{id}
        [HttpGet("{providerName}/{id}")]
        public async Task<IActionResult> GetAsync(string providerName, string id)
        {
            try
            {
                var provider = _providers.Get(providerName);

                provider.ValidateId(id);
                await Task.FromResult(1);

                return Ok(1);
            }
            catch (ProviderNotFoundException)
            {
                _logger.LogInformation("Provider was not found: {0}", providerName);
                return NotFound(new ErrorResponse("Provider not found."));
            }
            catch (InvalidIdException)
            {
                _logger.LogWarning("User provided an invalid id: {0}", id);
                return BadRequest(new ErrorResponse("Your provided id is not valid."));
            }
        }
    }
}