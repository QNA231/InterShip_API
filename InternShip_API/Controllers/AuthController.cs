using InternShip_API.PayLoads.DataRequests.AuthRequests;
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

        [HttpPost("Register")]
        public IActionResult Register([FromBody]Request_Register request)
        {
            return Ok(authServices.Register(request));
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]Request_Login request)
        {
            return Ok(authServices.Login(request));
        }
        [HttpPost("ConfrimCreateNewAccount")]
        public IActionResult ConfirmCreateNewAccount([FromBody] Request_CreateNewAccount request)
        {
            return Ok(authServices.ConfirmCreateNewAccount(request));
        }
        
    }
}
