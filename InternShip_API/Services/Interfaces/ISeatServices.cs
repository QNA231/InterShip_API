using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.SeatRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface ISeatServices
    {
        ResponseObject<DataResponse_Seat> CreateSeat(Request_CreateSeat request);
        List<Seat> CreateListSeat(int roomId, List<Request_CreateSeat> request);
        ResponseObject<DataResponse_Seat> UpdateSeat(Request_UpdateSeat request);
    }
}
