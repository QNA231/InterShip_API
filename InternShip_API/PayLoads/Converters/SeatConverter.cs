using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class SeatConverter
    {
        private readonly AppDbContext dbContext;

        public SeatConverter(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DataResponse_Seat EntityToDTO(Seat seat)
        {
            return new DataResponse_Seat
            {
                Number = seat.Number,
                SeatStatusName = dbContext.SeatStatuses.SingleOrDefault(x => x.Id == seat.SeatStatusId).NameStatus,
                Line = seat.Line,
                RoomName = dbContext.Rooms.SingleOrDefault(x => x.Id == seat.RoomId).Name,
                SeatTypeName = dbContext.SeatTypes.SingleOrDefault(x => x.Id == seat.SeatTypeId).NameType,
            };
        }
    }
}
