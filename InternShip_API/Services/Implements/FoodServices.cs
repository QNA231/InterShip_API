using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.Handels.HandleImage;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.FoodRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternShip_API.Services.Implements
{
    public class FoodServices : IFoodServices
    {
        private readonly AppDbContext dbContext;
        private readonly FoodConverter converter;
        private readonly ResponseObject<DataResponse_Food> responseObject;

        public FoodServices(FoodConverter converter, ResponseObject<DataResponse_Food> responseObject)
        {
            dbContext = new AppDbContext();
            this.converter = converter;
            this.responseObject = responseObject;
        }

        public async Task<ResponseObject<DataResponse_Food>> CreateFood(Request_CreateFood request)
        {
            if(dbContext.Foods.Any(x => x.NameOfFood == request.NameOfFood))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên đồ ăn đã tồn tại", null);
            }
            Food food = new Food();
            food.Price = request.Price;
            food.Description = request.Description;
            food.Image = await HandleUploadImage.UploadImage(request.Image);
            food.NameOfFood = request.NameOfFood;
            await dbContext.Foods.AddRangeAsync(food);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Thêm đồ ăn thành công", converter.EntityToDTO(food));
        }

        public async Task<ResponseObject<DataResponse_Food>> DeleteFood(int id)
        {
            if(await dbContext.Foods.AnyAsync(x => x.Id == id))
            {
                var food = await dbContext.Foods.FindAsync(id);
                dbContext.Foods.Remove(food);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Xóa thông tin đồ ăn thành công", null);
            }
            else
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Thông tin đồ ăn không tồn tại", null);
            }
        }

        public async Task<ResponseObject<DataResponse_Food>> UpdateFood(Request_UpdateFood request)
        {
            var food = await dbContext.Foods.SingleOrDefaultAsync(x => x.Id == request.Id);
            if(food == null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Thông tin đồ ăn không tồn tại", null);
            }
            food.Price = request.Price;
            food.Description = request.Description;
            food.Image = await HandleUpdateImage.UpdateImage(food.Image, request.Image);
            dbContext.Foods.Update(food);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Cập nhật thông tin đồ ăn thành công", converter.EntityToDTO(food));
        }
    }
}
