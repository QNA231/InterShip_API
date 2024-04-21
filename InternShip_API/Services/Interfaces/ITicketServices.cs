using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.TicketRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface ITicketServices
    {
        Task<ResponseObject<DataResponse_Ticket>> CreateTicket(int scheduleId, Request_CreateTicket request);
        Task<ResponseObject<DataResponse_Ticket>> UpdateTicket(Request_UpdateTicket request);
        List<Ticket> CreateListTicket(int scheduleId, List<Request_CreateTicket> request);
    }
}
