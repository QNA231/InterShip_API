using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.MovieRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;

namespace InternShip_API.Services.Implements
{
    public class MovieTypeServices : IMovieTypeServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_MovieType> responseObject;
        private readonly MovieTypeConverter converter;

        public MovieTypeServices(ResponseObject<DataResponse_MovieType> responseObject, MovieTypeConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public async Task<ResponseObject<DataResponse_MovieType>> CreateMovieType(Request_CreateMovieType request)
        {
            if (string.IsNullOrWhiteSpace(request.MovieTypeName))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }
            MovieType movieType = new MovieType
            {
                MovieTypeName = request.MovieTypeName,
                IsActive = true,
             };
            await dbContext.MovieTypes.AddAsync(movieType);
            dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Thêm thể loại phim thành công", converter.EntityToDTO(movieType));
        }

        public async Task<ResponseObject<DataResponse_MovieType>> DeleteMovieType(int movieTypeId)
        {
            if(dbContext.MovieTypes.Any(x => x.Id == movieTypeId))
            {
                var movieType = await dbContext.MovieTypes.FindAsync(movieTypeId);
                movieType.IsActive = false;
                dbContext.MovieTypes.Update(movieType);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Xóa thể loại phim thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy thể loại phim", null);
        }

        public async Task<ResponseObject<DataResponse_MovieType>> UpdateMovieType(Request_UpdateMovieType request)
        {
            if (dbContext.MovieTypes.Any(x => x.Id == request.Id))
            {
                var movieType = dbContext.MovieTypes.Find(request.Id);
                movieType.MovieTypeName = request.MovieTypeName;
                dbContext.MovieTypes.Update(movieType);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Cập nhật thể loại phim thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy thể loại phim", null);
        }
    }
}
