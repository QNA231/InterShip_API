using InternShip_API.PayLoads.DataRequests.PromotionRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IPromotionServices
    {
        Task<ResponseObject<DataResponse_Promotion>> CreatePromotion(Request_CreatePromotion request);
        Task<ResponseObject<DataResponse_Promotion>> UpdatePromotion(Request_UpdatePromotion request);
    }
}
