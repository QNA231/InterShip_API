using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class ScheduleConverter
    {
        private readonly AppDbContext dbContext;

        public ScheduleConverter(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DataResponse_Schedule EntityToDTO(Schedule schedule)
        {
            return new DataResponse_Schedule
            {
                Price = schedule.Price,
                StartAt = schedule.StartAt,
                EndAt = schedule.EndAt,
                Code = schedule.Code,
                MovieName = dbContext.Movies.SingleOrDefault(x => x.Id == schedule.MovieId).Name,
                Name = schedule.Name,
                RoomName = dbContext.Rooms.SingleOrDefault(x => x.Id == schedule.RoomId).Name,
            };
        }
    }
}
