using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.CinemaRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IRoomServices
    {
        ResponseObject<DataResponse_Room> CreateRoom(Request_CreateRoom request);
        Task<List<Room>> CreateListRoom(int cinemaId, List<Request_CreateRoom> request);
    }
}
