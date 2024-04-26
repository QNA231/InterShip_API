using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.PromotionRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;

namespace InternShip_API.Services.Implements
{
    public class PromotionServices : IPromotionServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_Promotion> responseObject;
        private readonly PromotionConverter converter;

        public PromotionServices(ResponseObject<DataResponse_Promotion> responseObject, PromotionConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public async Task<ResponseObject<DataResponse_Promotion>> CreatePromotion(Request_CreatePromotion request)
        {
            var rank = dbContext.RankCustomers.SingleOrDefault(x => x.Id == request.RankCustomerId);
            if (rank == null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy rank phù hợp", null);
            }
            Promotion promotion = new Promotion
            {
                Percent = request.Percent,
                Quantity = request.Quantity,
                Type = request.Type,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Description = request.Description,
                Name = request.Name
            };
            await dbContext.Promotions.AddAsync(promotion);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Thêm khuyến mãi thành công", converter.EntityToDTO(promotion));
        }

        public async Task<ResponseObject<DataResponse_Promotion>> DeletePromotion(Request_UpdatePromotion request)
        {
            Promotion promotion = dbContext.Promotions.SingleOrDefault(x => x.Id == request.Id);
            if (promotion != null)
            {
                dbContext.Promotions.Remove(promotion);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Xóa khuyến mãi thành công", converter.EntityToDTO(promotion));
            }
            else
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy khuyến mãi", null);
            }
        }

        public async Task<ResponseObject<DataResponse_Promotion>> UpdatePromotion(Request_UpdatePromotion request)
        {
            Promotion promotion = dbContext.Promotions.SingleOrDefault(x => x.Id == request.Id);
            if (promotion != null)
            {
                promotion.Percent = request.Percent;
                promotion.Quantity = request.Quantity;
                promotion.Type = request.Type;
                promotion.StartTime = request.StartTime;
                promotion.EndTime = request.EndTime;
                promotion.Description = request.Description;
                promotion.Name = request.Name;
                dbContext.Promotions.Update(promotion);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Cập nhật thông tin khuyến mãi thành công", converter.EntityToDTO(promotion));
            }
            else
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy khuyến mãi", null);
            }
        }
    }
}
