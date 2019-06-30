using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace havuclukek.gatewayAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            _logger.LogInformation($"get request : {DateTime.UtcNow}");

            return "for seeing re-routes list (configuration), make request to /configuration by authenticated token";
        }
    }
}
