using InternShip_API.PayLoads.DataRequests.UserRequests;
using InternShip_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternShip_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public UserController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePass(Request_ChangePassWord request)
        {
            int userId = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(authServices.ChangePassWord(request, userId));
        }
    }
}
