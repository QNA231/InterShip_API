using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.ScheduleRequests
{
    public class Request_CreateSchedule
    {
        public double Price { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Code { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }
    }
}
