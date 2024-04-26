using InternShip_API.PayLoads.DataRequests.RankCustomerRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IRankServices
    {
        Task<ResponseObject<DataResponse_RankCustomer>> CreateRank(Request_CreateRankCustomer request);
        Task<ResponseObject<DataResponse_RankCustomer>> UpdateRank(Request_UpdateRankCustomer request);
        Task<ResponseObject<DataResponse_RankCustomer>> DeleteRank(Request_UpdateRankCustomer request);
    }
}
