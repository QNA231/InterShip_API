using InternShip_API.PayLoads.DataRequests.VnPayRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IVnPayServices
    {
        string CreatePaymentUrl(HttpContext context, Request_VnPay request);
        VnPaymentResponseModel PaymentExecute(IQueryCollection collection);
    }
}
