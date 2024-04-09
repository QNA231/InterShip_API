using InternShip_API.PayLoads.DataRequests.FoodRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IFoodServices
    {
        Task<ResponseObject<DataResponse_Food>> CreateFood(Request_CreateFood request);
        Task<ResponseObject<DataResponse_Food>> UpdateFood(Request_UpdateFood request);
        Task<ResponseObject<DataResponse_Food>> DeleteFood(int id);
    }
}
