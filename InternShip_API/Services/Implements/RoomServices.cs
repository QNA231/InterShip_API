using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.Handels.HandleGenerate;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.CinemaRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternShip_API.Services.Implements
{
    public class RoomServices : IRoomServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_Room> roomResponseObject;
        private readonly RoomConverter roomConverter;
        private readonly ISeatServices seatServices;
        public async Task<List<Room>> CreateListRoom(int cinemaId, List<Request_CreateRoom> request)
        {
            var cinema = dbContext.Cinemas.SingleOrDefaultAsync(x => x.Id == cinemaId);
            if(cinema == null)
            {
                return null;
            }
            List<Room> rooms = new List<Room>();
            foreach(var req in request)
            {
                Room room = new Room();
                room.Capacity = req.Capacity;
                room.CinemaId = cinemaId;
                room.Code = HandleGenerateCodes.GenerateCode();
                room.Description = req.Description;
                room.Name = req.Name;
                room.Type = req.Type;
                await dbContext.Rooms.AddAsync(room);
                room.Seats = seatServices.CreateListSeat(room.Id, req.request_CreateSeats);
                rooms.Add(room);
            }
            await dbContext.SaveChangesAsync();
            return rooms;
        }

        public async Task<ResponseObject<DataResponse_Room>> CreateRoom(Request_CreateRoom request)
        {
            if(dbContext.Cinemas.Any(x => x.Id == request.CinemaId))
            {
                Room room = new Room();
                room.Capacity = request.Capacity;
                room.Type = request.Type;
                room.Description = request.Description;
                //room.CinemaId = request.CinemaId;
                room.Code = request.Code;
                room.Name = request.Name;
                room.Seats = request.request_CreateSeats == null ? null : seatServices.CreateListSeat(room.Id, request.request_CreateSeats);
                dbContext.Rooms.Update(room);
                await dbContext.SaveChangesAsync();
                return roomResponseObject.ResponseSuccess("Thêm phòng cho rạp thành công", roomConverter.EntityToDTO(room));
            }
            return roomResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Rạp phim không tồn tại", null);
        }

        public async Task<ResponseObject<DataResponse_Room>> DeleteRoom(Request_UpdateRoom request)
        {
            if (dbContext.Rooms.Any(x => x.Id == request.Id))
            {
                var room = dbContext.Rooms.Find(request.Id);
                if (room.Seats != null)
                {
                    dbContext.Seats.RemoveRange(room.Seats);
                }
                dbContext.Rooms.Remove(room);
                await dbContext.SaveChangesAsync();
                return roomResponseObject.ResponseSuccess("Xóa phòng thành công", roomConverter.EntityToDTO(room));
            }
            return roomResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy phòng", null);
        }

        public async Task<ResponseObject<DataResponse_Room>> UpdateRoom(Request_UpdateRoom request)
        {
            var cinema = dbContext.Cinemas.SingleOrDefault(x => x.Id == request.CinemaId);
            if(cinema == null)
            {
                return roomResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Rạp phim không tồn tại", null);
            }
            var room = dbContext.Rooms.Find(request.Id);
            if(room == null)
            {
                return roomResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy phòng", null);
            }
            room.Capacity = request.Capacity;
            room.Type = request.Type;
            room.Description = request.Description;
            room.CinemaId = cinema.Id;
            room.Code= HandleGenerateCodes.GenerateCode();
            room.Name = request.Name;
            var listSeat = dbContext.Seats.Include(x => x.Tickets).AsNoTracking().Where(x => x.RoomId == room.Id).ToList();
            foreach(var seat in listSeat)
            {
                var ticket = dbContext.Tickets.Include(x => x.BillTickets).Include(x => x.Schedule).AsNoTracking().Where(x => x.SeatId == seat.Id).ToList();
                dbContext.Tickets.RemoveRange(ticket);
                dbContext.Seats.Remove(seat);
            }
            room.Seats = request.request_CreateSeats == null ? null : seatServices.CreateListSeat(room.Id, request.request_CreateSeats);

            dbContext.Rooms.Update(room);
            await dbContext.SaveChangesAsync();
            return roomResponseObject.ResponseSuccess("Cập nhật thông tin phòng thành công", roomConverter.EntityToDTO(room));
        }
    }
}
