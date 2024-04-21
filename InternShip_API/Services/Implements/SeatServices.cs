using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.SeatRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;

namespace InternShip_API.Services.Implements
{
    public class SeatServices : ISeatServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_Seat> seatResponseObject;
        private readonly SeatConverter seatConverter;
        private readonly ITicketServices ticketServices;

        public SeatServices(ResponseObject<DataResponse_Seat> seatResponseObject, SeatConverter seatConverter, ITicketServices ticketServices)
        {
            dbContext = new AppDbContext();
            this.seatResponseObject = seatResponseObject;
            this.seatConverter = seatConverter;
            this.ticketServices = ticketServices;
        }


        public async Task<ResponseObject<DataResponse_Seat>> CreateSeat(Request_CreateSeat request)
        {
            var room = dbContext.Rooms.SingleOrDefault(x => x.Id == request.RoomId);
            if(room == null)
            {
                return seatResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy phòng", null);
            }
            if(dbContext.Seats.Any(x => x.Number == request.Number) && dbContext.Seats.Any(x => x.Line == request.Line))
            {
                return seatResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Ghế đã tồn tại", null);
            }
            Seat seat = new Seat();
            seat.IsActive = true;
            seat.SeatStatusId = 1;
            seat.Number = request.Number;
            seat.Line = request.Line;
            seat.RoomId = request.RoomId;
            seat.SeatTypeId = request.SeatTypeId;
            await dbContext.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            return seatResponseObject.ResponseSuccess("Thêm chỗ ngồi thành công", seatConverter.EntityToDTO(seat));
        }

        public async Task<ResponseObject<DataResponse_Seat>> UpdateSeat(Request_UpdateSeat request)
        {
            var seat = dbContext.Seats.SingleOrDefault(x => x.Id == request.Id);
            if (seat != null)
            {
                return seatResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy ghế", null);
            }
            seat.Number = request.Number;
            seat.Line = request.Line;
            seat.SeatStatusId = request.SeatStatusId;
            seat.SeatTypeId = request.SeatTypeId;
            seat.RoomId = request.RoomId;
            dbContext.Seats.Update(seat);
            await dbContext.SaveChangesAsync();
            return seatResponseObject.ResponseSuccess("Cập nhật ghế thành công", seatConverter.EntityToDTO(seat));
        }

        public List<Seat> CreateListSeat(int roomId, List<Request_CreateSeat> request)
        {
            var room = dbContext.Rooms.SingleOrDefault(x => x.Id == roomId);
            if(room == null)
            {
                return null;
            }
            List<Seat> seats = new List<Seat>();
            foreach(var item in request)
            {
                Seat seat = new Seat();
                seat.SeatStatusId = 1;
                seat.Number=item.Number;
                seat.Line = item.Line;
                seat.SeatTypeId = item.SeatTypeId;
                seat.RoomId = roomId;
                seat.IsActive = true;
                seats.Add(seat);
            }
            dbContext.Seats.AddRange(seats);
            dbContext.SaveChanges();
            return seats;
        }
    }
}
