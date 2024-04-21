using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.AuthRequests;
using InternShip_API.PayLoads.DataRequests.UserRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;

namespace InternShip_API.Services.Interfaces
{
    public interface IAuthServices
    {
        ResponseObject<DataResponse_Token> Login(Request_Login request);
        ResponseObject<DataResponse_User> Register(Request_Register request);
        DataResponse_Token GenerateAccessToken(User user);
        DataResponse_Token RenewAccessToken(Request_RenewAccessToken request);
        ResponseObject<DataResponse_User> ChangePassWord(Request_ChangePassWord request, int userId);
        Task<string> ConfirmCreateNewAccount(string code);
    }
}
