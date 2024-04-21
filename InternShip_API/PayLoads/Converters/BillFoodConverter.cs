using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class BillFoodConverter
    {
        private readonly AppDbContext dbContext;

        public BillFoodConverter(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DataResponse_BillFood EntityToDTO(BillFood billFood)
        {
            return new DataResponse_BillFood
            {
                Quantity = billFood.Quantity,
                FoodName = dbContext.Foods.SingleOrDefault(x => x.Id == billFood.FoodId).NameOfFood,
            };
        }
    }
}
