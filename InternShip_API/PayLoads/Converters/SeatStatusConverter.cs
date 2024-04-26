using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class SeatStatusConverter
    {
        public DataResponse_SeatStatus EntityToDTO(SeatStatus seatStatus)
        {
            return new DataResponse_SeatStatus{
                NameStatus = seatStatus.NameStatus,
            };
        }
    }
}
