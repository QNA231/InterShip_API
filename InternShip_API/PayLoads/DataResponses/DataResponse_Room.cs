using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Room
    {
        public int Capacity { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public IQueryable<DataResponse_Seat> dataResponse_Seats { get; set; }
        public IQueryable<DataResponse_Schedule> dataResponse_Schedules { get; set; }
    }
}
