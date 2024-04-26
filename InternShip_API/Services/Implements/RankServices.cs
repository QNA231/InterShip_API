using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.RankCustomerRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;

namespace InternShip_API.Services.Implements
{
    public class RankServices : IRankServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_RankCustomer> responseObject;
        private readonly RankCustomerConverter converter;

        public RankServices(ResponseObject<DataResponse_RankCustomer> responseObject, RankCustomerConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public async Task<ResponseObject<DataResponse_RankCustomer>> CreateRank(Request_CreateRankCustomer request)
        {
            RankCustomer rankCustomer = new RankCustomer();
            rankCustomer.Name = request.Name;
            rankCustomer.Description = request.Description;
            rankCustomer.Point = request.Point;
            await dbContext.RankCustomers.AddAsync(rankCustomer);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Thêm hạng thành công", converter.EntityToDTO(rankCustomer));
        }

        public async Task<ResponseObject<DataResponse_RankCustomer>> DeleteRank(Request_UpdateRankCustomer request)
        {
            var rank = dbContext.RankCustomers.SingleOrDefault(x => x.Id == request.Id);
            if (rank != null)
            {
                dbContext.RankCustomers.Remove(rank);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Xóa rank thành công", null);
            }
            else
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy rank phù hợp", null);
            }
        }

        public async Task<ResponseObject<DataResponse_RankCustomer>> UpdateRank(Request_UpdateRankCustomer request)
        {
            var rankCustomer = dbContext.RankCustomers.SingleOrDefault(x => x.Id == request.Id);
            if(rankCustomer == null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy hạng", null);
            }
            rankCustomer.Name = request.Name;
            rankCustomer.Description = request.Description;
            rankCustomer.Id = request.Id;
            rankCustomer.Point = request.Point;
            dbContext.RankCustomers.Update(rankCustomer);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Cập nhật thông tin hạng thành công", converter.EntityToDTO(rankCustomer));
        }
    }
}
