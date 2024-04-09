using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class RoomConverter
    {
        private readonly AppDbContext dbContext;
        private readonly SeatConverter seatConverter;
        private readonly ScheduleConverter scheduleConverter;

        public RoomConverter(AppDbContext dbContext, SeatConverter seatConverter, ScheduleConverter scheduleConverter)
        {
            this.dbContext = dbContext;
            this.seatConverter = seatConverter;
            this.scheduleConverter = scheduleConverter;
        }
        public DataResponse_Room EntityToDTO(Room room)
        {
            return new DataResponse_Room
            {
                Capacity = room.Capacity,
                Type = room.Type,
                Description = room.Description,
                Name = room.Name,
                dataResponse_Schedules = dbContext.Schedules.Where(x => x.RoomId == room.Id).Select(scheduleConverter.EntityToDTO(x)),
                dataResponse_Seats = dbContext.Seats.Where(x => x.RoomId == room.Id).Select(scheduleConverter.EntityToDTO(x)),
            };
        }
    }
}
