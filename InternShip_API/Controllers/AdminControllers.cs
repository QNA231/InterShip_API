using InternShip_API.PayLoads.DataRequests.CinemaRequests;
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
        private readonly ICinemaServices cinemaServices;

        public AdminControllers(IFoodServices foodServices, ICinemaServices cinemaServices)
        {
            this.foodServices = foodServices;
            this.cinemaServices = cinemaServices;
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
        public async Task<IActionResult> DeleteFood(int foodId)
        {
            return Ok(foodServices.DeleteFood(foodId));
        }
        #endregion

        #region CinemaServices
        [HttpPost("CreateCinema")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateCinema(Request_CreateCinema request)
        {
            return Ok(await cinemaServices.CreateCinema(request));
        }

        [HttpPut("UpdateCinema")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateCinema(Request_UpdateCinema request)
        {
            return Ok(await cinemaServices.UpdateCinema(request));
        }

        [HttpDelete("DeleteCinema")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteCinema(Request_UpdateCinema request)
        {
            return Ok(await cinemaServices.DeleteCinema(request));
        }
        #endregion

        #region RoomServices

        #endregion

        #region

        #endregion

        #region

        #endregion
    }
}
