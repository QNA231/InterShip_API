using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class FoodConverter
    {
        private readonly AppDbContext dbContext;

        public FoodConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_Food EntityToDTO(Food  food)
        {
            return new DataResponse_Food()
            {
                Price = food.Price,
                Description = food.Description,
                Image = food.Image,
                NameOfFood = food.NameOfFood,
            };
        }
    }
}
