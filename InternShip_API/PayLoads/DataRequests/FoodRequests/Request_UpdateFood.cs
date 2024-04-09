using System.ComponentModel.DataAnnotations;

namespace InternShip_API.PayLoads.DataRequests.FoodRequests
{
    public class Request_UpdateFood
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        public string NameOfFood { get; set; }
    }
}
