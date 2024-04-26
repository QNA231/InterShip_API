using InternShip_API.PayLoads.DataRequests.BillRequests;
using InternShip_API.PayLoads.DataRequests.CinemaRequests;
using InternShip_API.PayLoads.DataRequests.FoodRequests;
using InternShip_API.PayLoads.DataRequests.MovieRequests;
using InternShip_API.PayLoads.DataRequests.PromotionRequests;
using InternShip_API.PayLoads.DataRequests.RankCustomerRequests;
using InternShip_API.PayLoads.DataRequests.SeatRequests;
using InternShip_API.PayLoads.DataRequests.TicketRequests;
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
        private readonly IRoomServices roomServices;
        private readonly IPromotionServices promotionServices;
        private readonly IRankServices rankServices;
        private readonly ITicketServices ticketServices;
        private readonly IMovieServices movieServices;
        private readonly IMovieTypeServices movieTypeServices;
        private readonly ISeatServices seatServices;
        private readonly IBillServices billServices;

        public AdminControllers(IFoodServices foodServices, ICinemaServices cinemaServices, IRoomServices roomServices, IPromotionServices promotionServices, IRankServices rankServices, ITicketServices ticketServices, IMovieServices movieServices, IMovieTypeServices movieTypeServices, ISeatServices seatServices, IBillServices billServices)
        {
            this.foodServices = foodServices;
            this.cinemaServices = cinemaServices;
            this.roomServices = roomServices;
            this.promotionServices = promotionServices;
            this.rankServices = rankServices;
            this.ticketServices = ticketServices;
            this.movieServices = movieServices;
            this.movieTypeServices = movieTypeServices;
            this.seatServices = seatServices;
            this.billServices = billServices;
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
        [HttpPost("CreateRoom")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateRoom(Request_CreateRoom request)
        {
            return Ok(await roomServices.CreateRoom(request));
        }

        [HttpPut("UpdateRoom")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateRoom(Request_UpdateRoom request)
        {
            return Ok(await roomServices.UpdateRoom(request));
        }

        //[HttpDelete("DeleteRoom")]
        //[Authorize(Roles = "Admin, Manager")]

        #endregion

        #region PromotionServices
        [HttpPost("CreatePromotion")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreatePromotion(Request_CreatePromotion request)
        {
            return Ok(await promotionServices.CreatePromotion(request));
        }

        [HttpPut("UpdatePromotion")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdatePromotion(Request_UpdatePromotion request)
        {
            return Ok(await promotionServices.UpdatePromotion(request));
        }

        [HttpDelete("DeletePromotion")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeletePromotion(Request_UpdatePromotion request)
        {
            return Ok(await promotionServices.DeletePromotion(request));
        }
        #endregion

        #region RankCustomer
        [HttpPost("CreateRankCustomer")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateRankCustomer(Request_CreateRankCustomer request)
        {
            return Ok(await rankServices.CreateRank(request));
        }

        [HttpPut("UpdateRankCustomer")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateRankCustomer(Request_UpdateRankCustomer request)
        {
            return Ok(await rankServices.UpdateRank(request));
        }

        [HttpDelete("DeleteRankCustomer")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteRankCustomer(Request_UpdateRankCustomer request)
        {
            return Ok(await rankServices.DeleteRank(request));
        }
        #endregion

        #region TicketServices
        [HttpPost("CreateTicket")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateTicket(int scheduleId, Request_CreateTicket request)
        {
            return Ok(await ticketServices.CreateTicket(scheduleId, request)); 
        }

        [HttpPut("UpdateTicket")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateTicket(Request_UpdateTicket request)
        {
            return Ok(await ticketServices.UpdateTicket(request));
        }
        #endregion

        #region MovieServices
        [HttpPost("CreateMovieType")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateMovieType(Request_CreateMovieType request)
        {
            return Ok(await movieTypeServices.CreateMovieType(request));
        }

        [HttpPut("UpdateMovieType")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateMovieType(Request_UpdateMovieType request)
        {
            return Ok(await movieTypeServices.UpdateMovieType(request));
        }

        [HttpDelete("DeleteMovieType")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteMovieType(int movieTypeId)
        {
            return Ok(await movieTypeServices.DeleteMovieType(movieTypeId));
        }

        [HttpPost("CreateMovie")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateMovie(Request_CreateMovie request)
        {
            return Ok(await movieServices.CreateMovie(request));
        }

        [HttpPut("UpdateMovie")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateMovie(Request_UpdateMovie request)
        {
            return Ok(await movieServices.UpdateMovie(request));
        }

        [HttpDelete("DeleteMovie")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            return Ok(await movieServices.DeleteMovie(movieId));
        }
        #endregion

        #region SeatServices
        [HttpPost("CreateSeatType")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateSeatType(Request_SeatType request)
        {
            return Ok(await seatServices.CreateSeatType(request));
        }

        [HttpPut("UpdateSeatType")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateSeatType(Request_SeatType request)
        {
            return Ok(await seatServices.UpdateSeatType(request));
        }

        [HttpDelete("DeleteSeatType")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteSeatType(Request_SeatType request)
        {
            return Ok(await seatServices.DeleteSeatType(request));
        }

        [HttpPost("CreateSeat")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateSeat(Request_CreateSeat request)
        {
            return Ok(await seatServices.CreateSeat(request));
        }

        [HttpPut("UpdateSeat")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateSeat(Request_UpdateSeat request)
        {
            return Ok(await seatServices.UpdateSeat(request));
        }

        [HttpPost("CreateSeatStatus")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateSeatStatus(Request_SeatStatus request)
        {
            return Ok(await seatServices.CreateSeatStatus(request));
        }

        [HttpPut("UpdateSeatStatus")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateSeatStatus(Request_SeatStatus request)
        {
            return Ok(await seatServices.UpdateSeatStatus(request));
        }

        [HttpDelete("DeleteSeatStatus")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteSeatStatus(Request_SeatStatus request)
        {
            return Ok(await seatServices.DeleteSeatStatus(request));
        }
        #endregion

        #region BillServices
        [HttpPost("CreateBill")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateBill (Request_CreateBill request)
        {
            return Ok(await billServices.CreateBill(request));
        }

        [HttpPost("CreateBillFood")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateBillFood(int billId, Request_CreateBillFood request)
        {
            return Ok(await billServices.CreateBillFood(billId, request));
        }

        [HttpPost("CreateBillTicket")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateBillTicket(int billId, Request_CreateBillTicket request)
        {
            return Ok(await billServices.CreateBillTicket(billId, request));
        }
        #endregion

        #region 

        #endregion

        #region

        #endregion
    }
}
