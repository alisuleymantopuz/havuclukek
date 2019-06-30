using System;
using havuclukek.security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace havuclukek.identityServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        private ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Current()
        {
            return Ok($"Is authenticated: {User.Identity.IsAuthenticated}");
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            _logger.LogInformation($"get request : {DateTime.UtcNow}");

            var authToken = _userService.Authenticate(userParam.Username, userParam.Password);

            if (authToken == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(authToken);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("getAllUsers")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("getUser/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            return Ok(user);
        }
    }
}
