using InternShip_API.PayLoads.DataRequests.FoodRequests;
using InternShip_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternShip_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminControllers : ControllerBase
    {
        private readonly IFoodServices foodServices;

        public AdminControllers(IFoodServices foodServices)
        {
            this.foodServices = foodServices;
        }
        #region FoodServices
        [HttpPost("CreateFood")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateFood(Request_CreateFood request)
        {
            return Ok(await foodServices.CreateFood(request));
        }

        [HttpPut("UpdateFood")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateFood(Request_UpdateFood request)
        {
            return Ok(await foodServices.UpdateFood(request));
        }

        [HttpDelete("DeleteFood")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteFood()
        {
            int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
            return Ok(foodServices.DeleteFood(id));
        }
        #endregion

        #region

        #endregion

        #region

        #endregion

        #region

        #endregion

        #region

        #endregion
    }
}
