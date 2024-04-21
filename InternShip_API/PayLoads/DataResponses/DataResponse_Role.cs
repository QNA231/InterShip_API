namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Role
    {
        public string Code { get; set; }
        public string RoleName { get; set; }
        public IQueryable<DataResponse_User>? DataResponseUsers { get; set; }
    }
}
