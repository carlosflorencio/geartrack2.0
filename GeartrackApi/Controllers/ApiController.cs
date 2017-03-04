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
        // Searches for a provider and executes it
        [HttpGet("{providerName}/{id}")]
        public async Task<IActionResult> ParseProvider(string providerName, string id)
        {
            try
            {
                var provider = _providers.Get(providerName);

                var parsedId = id.ToUpper().Trim();
                provider.ValidateId(parsedId);

                var result = await provider.GetInformationAndParse(parsedId);

                return Ok(result);
            }
            catch(ProviderException) // Failed to parse of provider is offline
            {
                _logger.LogCritical("Provider is offline or changed is website: {0} {1}",
                    providerName, id);

                HttpContext.Response.StatusCode = 500;
                return Json(new ErrorResponse("Something is wrong with the provider."));
            }
            catch (InformationNotAvaiableException)
            {
                _logger.LogWarning("No information for this id was found: {0} {1}"
                    ,providerName, id);
                return NotFound(new ErrorResponse("No data was found for that id."));
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