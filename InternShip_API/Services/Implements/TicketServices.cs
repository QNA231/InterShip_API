using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.Handels.HandleGenerate;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.TicketRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;

namespace InternShip_API.Services.Implements
{
    public class TicketServices : ITicketServices
    {
        private readonly AppDbContext dbContext;
        private readonly TicketConverter ticketConverter;
        private readonly ResponseObject<DataResponse_Ticket> ticketResponseObject;

        public TicketServices(TicketConverter ticketConverter, ResponseObject<DataResponse_Ticket> ticketResponseObject)
        {
            dbContext = new AppDbContext();
            this.ticketConverter = ticketConverter;
            this.ticketResponseObject = ticketResponseObject;
        }

        public List<Ticket> CreateListTicket(int scheduleId, List<Request_CreateTicket> request)
        {
            if (dbContext.Schedules.Any(x => x.Id != scheduleId))
            {
                throw new ArgumentException("Không tìm thấy thông tin phim");
            }
            List<Ticket> list = new List<Ticket>();
            foreach (var item in request)
            {
                Ticket ticket = new Ticket
                {
                    ScheduleId = scheduleId,
                    SeatId = item.SeatId,
                    Code = "Movie_" + HandleGenerateCodes.GenerateCode(),
                };
                list.Add(ticket);
            };
            dbContext.Tickets.AddRange(list);
            dbContext.SaveChangesAsync();
            return list;
        }

        public async Task<ResponseObject<DataResponse_Ticket>> CreateTicket(int scheduleId, Request_CreateTicket request)
        {
            var seat = dbContext.Seats.SingleOrDefault(x => x.Id == request.SeatId);
            if(seat == null)
            {
                return ticketResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy ghế", null);
            }
            if(dbContext.Schedules.Any(x => x.Id != scheduleId))
            {
                return ticketResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy thông tin phim", null);
            }
            Ticket ticket = new Ticket
            {
                ScheduleId = scheduleId,
                SeatId = request.SeatId,
                Code = "Movie_" + HandleGenerateCodes.GenerateCode(),
            };
            await dbContext.Tickets.AddAsync(ticket);
            await dbContext.SaveChangesAsync();
            return ticketResponseObject.ResponseSuccess("Tạo vé thành công", ticketConverter.EntityToDTO(ticket));
        }

        public async Task<ResponseObject<DataResponse_Ticket>> UpdateTicket(Request_UpdateTicket request)
        {
            var ticket = dbContext.Tickets.SingleOrDefault(x => x.Id == request.Id);
            if(ticket == null)
            {
                return ticketResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy vé", null);
            }
            ticket.ScheduleId = request.ScheduleId;
            ticket.SeatId = request.SeatId;
            ticket.Id = request.Id;
            dbContext.Tickets.Update(ticket);
            await dbContext.SaveChangesAsync();
            return ticketResponseObject.ResponseSuccess("Cập nhật thông tin vé thành công", ticketConverter.EntityToDTO(ticket));
        }
    }
}
