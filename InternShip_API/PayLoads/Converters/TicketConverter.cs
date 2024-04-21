using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class TicketConverter
    {
        private readonly AppDbContext dbContext;

        public TicketConverter(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DataResponse_Ticket EntityToDTO(Ticket ticket)
        {
            return new DataResponse_Ticket
            {
                Code = ticket.Code,
                ScheduleName = dbContext.Schedules.SingleOrDefault(x => x.Id == ticket.ScheduleId).Name,
                SeatNumber = dbContext.Seats.SingleOrDefault(x => x.Id == ticket.SeatId).Number,
                SeatLine = dbContext.Seats.SingleOrDefault(x => x.Id == ticket.SeatId).Line,
                PriceTicket = ticket.PriceTicket,
            };
        }
    }
}
