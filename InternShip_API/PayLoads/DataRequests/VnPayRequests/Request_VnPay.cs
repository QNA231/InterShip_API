namespace InternShip_API.PayLoads.DataRequests.VnPayRequests
{
    public class Request_VnPay
    {
        public int? BillId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
