using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.MovieRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.IO;
using InternShip_API.Handels.HandleImage;
using Microsoft.EntityFrameworkCore;
using System;

namespace InternShip_API.Services.Implements
{
    public class MovieServices : IMovieServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_Movie> responseObject;
        private readonly MovieConverter converter;

        public MovieServices(ResponseObject<DataResponse_Movie> responseObject, MovieConverter converter)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.converter = converter;
        }

        public async Task<ResponseObject<DataResponse_Movie>> CreateMovie(Request_CreateMovie request)
        {
            var movieType = dbContext.MovieTypes.SingleOrDefault(x => x.Id == request.MovieTypeId);
            if(movieType == null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy thể loại phim", null);
            }
            var strUp = new Task<string>[]
            {
                HandleUploadImage.UploadImage(request.Image),
                HandleUploadImage.UploadImage(request.HeroImage),
            };
            var uploadResult = await Task.WhenAll(strUp);
            Movie movie = new Movie
            {
                MovieDuration = request.MovieDuration,
                EndTime = request.EndTime,
                PremiereDate = request.PremiereDate,
                Description = request.Description,
                Director = request.Director,
                Image = uploadResult[0],
                HeroImage = uploadResult[1],
                Language = request.Language,
                MovieTypeId = request.MovieTypeId,
                Name = request.Name,
                RateId = request.RateId,
                Traler = request.Traler,
                IsActive = true,
            };
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Thêm thông tin phim thành công", converter.EntityToDTO(movie));
        }

        public async Task<ResponseObject<DataResponse_Movie>> DeleteMovie(int movieId)
        {
            if (dbContext.Movies.Any(x => x.Id == movieId))
            {
                var movie = dbContext.Movies.Find(movieId);
                movie.IsActive = false;
                dbContext.Movies.Update(movie);
                await dbContext.SaveChangesAsync();
                return responseObject.ResponseSuccess("Xóa phim thành công", null);
            }
            return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy phim", null);
        }

        public async Task<ResponseObject<DataResponse_Movie>> UpdateMovie(Request_UpdateMovie request)
        {
            var movie = dbContext.Movies.SingleOrDefault(x => x.Id == request.Id);
            if(movie == null)
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy phim", null);
            }
            if(!dbContext.MovieTypes.Any(x => x.Id == request.MovieTypeId))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy thể loại", null);
            }
            var strUp = new Task<string>[]
            {
                HandleUpdateImage.UpdateImage(movie.Image, request.Image),
            };
            var uploadResult = await Task.WhenAll(strUp);
            movie.MovieDuration = request.MovieDuration;
            movie.EndTime = request.EndTime;
            movie.PremiereDate = request.PremiereDate;
            movie.Description = request.Description;
            movie.Director = request.Director;
            movie.Image = uploadResult[0];
            movie.Language = request.Language;
            movie.MovieTypeId = request.MovieTypeId;
            movie.Name = request.Name;
            movie.RateId = request.RateId;
            movie.Traler = request.Traler;
            dbContext.Movies.Update(movie);
            await dbContext.SaveChangesAsync();
            return responseObject.ResponseSuccess("Cập nhật thông tin phim thành công", converter.EntityToDTO(movie));
        }
    }
}
