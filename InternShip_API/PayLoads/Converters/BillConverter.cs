using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class BillConverter
    {
        private readonly AppDbContext dbContext;
        private readonly BillFoodConverter billFoodConverter;
        private readonly BillTicketConverter billTicketConverter;

        public BillConverter(AppDbContext dbContext, BillFoodConverter billFoodConverter, BillTicketConverter billTicketConverter)
        {
            this.dbContext = dbContext;
            this.billFoodConverter = billFoodConverter;
            this.billTicketConverter = billTicketConverter;
        }
        public DataResponse_Bill EntityToDTO(Bill bill)
        {
            return new DataResponse_Bill
            {
                TotalMoney = bill.TotalMoney,
                TradingCode = bill.TradingCode,
                CreateTime = bill.CreateTime,
                CustomerName = dbContext.Users.SingleOrDefault(x => x.Id == bill.CustomerId).Name,
                Name = bill.Name,
                PromotionPercent = dbContext.Promotions.SingleOrDefault(x => x.Id == bill.PromotionId).Percent,
                BillStatusName = dbContext.BillStatuses.SingleOrDefault(x => x.Id == bill.BillStatusId).Name,
                BillFoods = dbContext.BillFoods.Where(x => x.BillId == bill.Id).Select(x => billFoodConverter.EntityToDTO(x)),
                BillTickets = dbContext.BillTickets.Where(x => x.BillId == bill.Id).Select(x => billTicketConverter.EntityToDTO(x)),
            };
        } 
    }
}
