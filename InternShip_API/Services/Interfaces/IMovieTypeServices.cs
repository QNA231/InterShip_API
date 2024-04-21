using InternShip_API.PayLoads.DataRequests.MovieRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IMovieTypeServices
    {
        Task<ResponseObject<DataResponse_MovieType>> CreateMovieType(Request_CreateMovieType request);
        Task<ResponseObject<DataResponse_MovieType>> UpdateMovieType(Request_UpdateMovieType request);
        Task<ResponseObject<DataResponse_MovieType>> DeleteMovieType(int movieTypeId);
    }
}
