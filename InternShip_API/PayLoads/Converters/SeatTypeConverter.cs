using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class SeatTypeConverter
    {
        public DataResponse_SeatType EntityToDTO(SeatType seatType)
        {
            return new DataResponse_SeatType
            {
                SeatType = seatType.NameType,
            };
        }
    }
}
