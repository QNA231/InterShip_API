using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.SeatRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface ISeatServices
    {
        Task<ResponseObject<DataResponse_Seat>> CreateSeat(Request_CreateSeat request);
        List<Seat> CreateListSeat(int roomId, List<Request_CreateSeat> request);
        Task<ResponseObject<DataResponse_Seat>> UpdateSeat(Request_UpdateSeat request);

        Task<ResponseObject<DataResponse_SeatType>> CreateSeatType(Request_SeatType request);
        Task<ResponseObject<DataResponse_SeatType>> UpdateSeatType(Request_SeatType request);
        Task<ResponseObject<DataResponse_SeatType>> DeleteSeatType(Request_SeatType request);

        Task<ResponseObject<DataResponse_SeatStatus>> CreateSeatStatus(Request_SeatStatus request);
        Task<ResponseObject<DataResponse_SeatStatus>> UpdateSeatStatus(Request_SeatStatus request);
        Task<ResponseObject<DataResponse_SeatStatus>> DeleteSeatStatus(Request_SeatStatus request);
    }
}
