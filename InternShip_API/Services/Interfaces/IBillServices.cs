using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.BillRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IBillServices
    {
        Task<ResponseObject<DataResponse_Bill>> CreateBill(Request_CreateBill request);
        Task<ResponseObject<DataResponse_BillFood>> CreateBillFood(int billId, Request_CreateBillFood request);
        Task<List<BillFood>> CreateListBillFood(int billId, List<Request_CreateBillFood> request);
        Task<ResponseObject<DataResponse_BillTicket>> CreateBillTicket(int billId, Request_CreateBillTicket request);
        Task<List<BillTicket>> CreateListBillTicket(int billId, List<Request_CreateBillTicket> request);
    }
}
