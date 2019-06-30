using System;
using System.Collections.Generic;
using havuclukek.security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace havuclukek.CatalogServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation($"get request : {DateTime.UtcNow}");

            return new string[] { "value1", "value2" };
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}
