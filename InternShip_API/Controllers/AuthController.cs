using InternShip_API.PayLoads.DataRequests;
using InternShip_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternShip_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public AuthController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]Request_Login request)
        {
            return Ok(authServices.Login(request));
        }
    }
}
