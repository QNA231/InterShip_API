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
        private readonly ResponseObject<DataResponse_SeatType> seatTypeResponseObject;
        private readonly ResponseObject<DataResponse_SeatStatus> seatStatusResponseObject;
        private readonly SeatConverter seatConverter;
        private readonly SeatTypeConverter typeConverter;
        private readonly SeatStatusConverter statusConverter;

        public SeatServices(ResponseObject<DataResponse_Seat> seatResponseObject, ResponseObject<DataResponse_SeatType> seatTypeResponseObject, ResponseObject<DataResponse_SeatStatus> seatStatusResponseObject, SeatConverter seatConverter, SeatStatusConverter statusConverter, SeatTypeConverter typeConverter)
        {
            dbContext = new AppDbContext();
            this.seatResponseObject = seatResponseObject;
            this.seatTypeResponseObject = seatTypeResponseObject;
            this.seatStatusResponseObject = seatStatusResponseObject;
            this.seatConverter = seatConverter;
            this.statusConverter = statusConverter;
            this.typeConverter = typeConverter;
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


        public async Task<ResponseObject<DataResponse_SeatType>> CreateSeatType(Request_SeatType request)
        {
            SeatType seatType = new SeatType
            {
                NameType = request.NameType
            };
            await dbContext.SeatTypes.AddAsync(seatType);
            await dbContext.SaveChangesAsync();
            return seatTypeResponseObject.ResponseSuccess("Thêm loại ghế thành công", typeConverter.EntityToDTO(seatType));
        }

        public async Task<ResponseObject<DataResponse_SeatType>> UpdateSeatType(Request_SeatType request)
        {
            var seat = dbContext.SeatTypes.SingleOrDefault(x => x.Id == request.Id);
            if(seat == null)
            {
                return seatTypeResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy loại ghế", null);
            }
            seat.NameType = request.NameType;
            dbContext.SeatTypes.Update(seat);
            await dbContext.SaveChangesAsync();
            return seatTypeResponseObject.ResponseSuccess("Cập nhật loại ghế thành công", typeConverter.EntityToDTO(seat));
        }

        public async Task<ResponseObject<DataResponse_SeatType>> DeleteSeatType(Request_SeatType request)
        {
            var seat = dbContext.SeatTypes.SingleOrDefault(x => x.Id == request.Id);
            if (seat == null)
            {
                return seatTypeResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy loại ghế", null);
            }
            dbContext.SeatTypes.Remove(seat);
            await dbContext.SaveChangesAsync();
            return seatTypeResponseObject.ResponseSuccess("Xóa loại ghế thành công", typeConverter.EntityToDTO(seat));
        }


        public async Task<ResponseObject<DataResponse_SeatStatus>> CreateSeatStatus(Request_SeatStatus request)
        {
            SeatStatus seat = new SeatStatus();
            seat.NameStatus = request.NameStatus;
            seat.Code = request.Code;
            await dbContext.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            return seatStatusResponseObject.ResponseSuccess("Thêm tình trạng cho ghế thành công", statusConverter.EntityToDTO(seat));
        }

        public async Task<ResponseObject<DataResponse_SeatStatus>> UpdateSeatStatus(Request_SeatStatus request)
        {
            var seat = dbContext.SeatStatuses.SingleOrDefault(x => x.Id == request.Id);
            if (seat == null)
            {
                return seatStatusResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy tình trạng ghế", null);
            }
            seat.NameStatus = request.NameStatus;
            dbContext.SeatStatuses.Update(seat);
            await dbContext.SaveChangesAsync();
            return seatStatusResponseObject.ResponseSuccess("Cập nhật tình trạng ghế thành công", statusConverter.EntityToDTO(seat));
        }

        public async Task<ResponseObject<DataResponse_SeatStatus>> DeleteSeatStatus(Request_SeatStatus request)
        {
            var seat = dbContext.SeatStatuses.SingleOrDefault(x => x.Id == request.Id);
            if (seat == null)
            {
                return seatStatusResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy tình trạng ghế", null);
            }
            dbContext.SeatStatuses.Remove(seat);
            await dbContext.SaveChangesAsync();
            return seatStatusResponseObject.ResponseSuccess("Xóa tình trạng ghế thành công", statusConverter.EntityToDTO(seat));
        }
    }
}
