using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Cinema
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public string NameOfCinema { get; set; }
        public IQueryable<DataResponse_Room> dataResponse_Rooms { get; set; }
    }
}
