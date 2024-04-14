using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.CinemaRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IRoomServices
    {
        Task<ResponseObject<DataResponse_Room>> CreateRoom(Request_CreateRoom request);
        Task<List<Room>> CreateListRoom(int cinemaId, List<Request_CreateRoom> request);
        Task<ResponseObject<DataResponse_Room>> UpdateRoom(Request_UpdateRoom request);
        Task<ResponseObject<DataResponse_Room>> DeleteRoom(Request_UpdateRoom request);
    }
}
