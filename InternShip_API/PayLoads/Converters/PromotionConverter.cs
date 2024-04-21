using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class PromotionConverter
    {
        public DataResponse_Promotion EntityToDTO(Promotion promotion)
        {
            return new DataResponse_Promotion
            {
                Percent = promotion.Percent,
                Quantity = promotion.Quantity,
                Type = promotion.Type,
                StartTime = promotion.StartTime,
                EndTime = promotion.EndTime,
                Description = promotion.Description,
                Name = promotion.Name,
            };
        }
    }
}
