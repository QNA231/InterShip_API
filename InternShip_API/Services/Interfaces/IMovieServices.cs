using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.MovieRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<ResponseObject<DataResponse_Movie>> CreateMovie(Request_CreateMovie request);
        Task<ResponseObject<DataResponse_Movie>> UpdateMovie(Request_UpdateMovie request);
        Task<ResponseObject<DataResponse_Movie>> DeleteMovie(int movieId);
    }
}
