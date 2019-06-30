using System.Collections.Generic;
using havuclukek.security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace havuclukek.CatalogServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
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
