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
        private readonly ResponseObject<DataResponse_Room> seatResponseObject;
        private readonly SeatConverter seatConverter;
        private readonly ITicketServices ticketServices;

        public SeatServices(ResponseObject<DataResponse_Room> seatResponseObject, SeatConverter seatConverter, ITicketServices ticketServices)
        {
            dbContext = new AppDbContext();
            this.seatResponseObject = seatResponseObject;
            this.seatConverter = seatConverter;
            this.ticketServices = ticketServices;
        }

        public Task<List<Seat>> CreateListSeat(int roomId, List<Request_CreateSeat> request)
        {
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponse_Seat> CreateSeat(Request_CreateSeat request)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> UpdateListSeat(int roomId, List<Request_UpdateSeat> request)
        {
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponse_Seat> UpdateSeat(Request_UpdateSeat request)
        {
            throw new NotImplementedException();
        }
    }
}
