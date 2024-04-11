using InternShip_API.PayLoads.DataRequests.CinemaRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface ICinemaServices
    {
        Task<ResponseObject<DataResponse_Cinema>> CreateCinema(Request_CreateCinema request);
        Task<ResponseObject<DataResponse_Cinema>> UpdateCinema(Request_UpdateCinema request);
        Task<ResponseObject<DataResponse_Cinema>> DeleteCinema(Request_UpdateCinema request);
    }
}
