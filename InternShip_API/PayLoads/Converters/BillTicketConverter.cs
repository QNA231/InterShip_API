using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class BillTicketConverter
    {
        private readonly AppDbContext dbContext;

        public BillTicketConverter(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DataResponse_BillTicket EntityToDTO(BillTicket billTicket)
        {
            var seat = dbContext.Seats.SingleOrDefault(x => x.Tickets.Any(z => z.Id == billTicket.TicketId));
            if(seat == null)
            {
                return null;
            }
            return new DataResponse_BillTicket
            {
                Quantity = billTicket.Quantity,
                SeatLine = seat.Line,
                SeatNumber = seat.Number,
            };
        }
    }
}
