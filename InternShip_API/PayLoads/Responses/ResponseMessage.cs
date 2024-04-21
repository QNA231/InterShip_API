namespace InternShip_API.PayLoads.Responses
{
    public class ResponseMessage
    {
        public static string GetEmailMessage(string email)
        {
            return $"Email đã được gửi đến : {email}";
        }
    }
}
