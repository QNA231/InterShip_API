using InternShip_API.PayLoads.DataRequests.UserRequests;
using InternShip_API.PayLoads.DataRequests.VnPayRequests;
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
        private readonly IVnPayServices vnPayServices;

        public UserController(IAuthServices authServices, IVnPayServices vnPayServices)
        {
            this.authServices = authServices;
            this.vnPayServices = vnPayServices;
        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePass(Request_ChangePassWord request)
        {
            int userId = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(authServices.ChangePassWord(request, userId));
        }

        [HttpPost("PaymentCallBack")]
        public IActionResult PaymentCallBack(Request_VnPay request)
        {
            var result = vnPayServices.PaymentExecute(Request.Query);
            if(result == null || result.VnPayResponseCode == "00")
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            return Ok();
        }
    }
}
