using Azure.Core;
using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.Handels.HandleImage;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.CinemaRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;

namespace InternShip_API.Services.Implements
{
    public class CinemaServices : ICinemaServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_Cinema> cinemaResponseObject;
        private readonly CinemaConverter cinemaConverter;
        private readonly IRoomServices roomServices;

        public CinemaServices(ResponseObject<DataResponse_Cinema> cinemaResponseObject, CinemaConverter cinemaConverter, IRoomServices roomServices)
        {
            dbContext = new AppDbContext();
            this.cinemaResponseObject = cinemaResponseObject;
            this.cinemaConverter = cinemaConverter;
            this.roomServices = roomServices;
        }

        public async Task<ResponseObject<DataResponse_Cinema>> CreateCinema(Request_CreateCinema request)
        {
            if (string.IsNullOrWhiteSpace(request.Address) || string.IsNullOrWhiteSpace(request.Description) || string.IsNullOrWhiteSpace(request.Code) || string.IsNullOrWhiteSpace(request.NameOfCinema))
            {
                return cinemaResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đầy đủ thông tin", null);
            }
            Cinema cinema = new Cinema();
            cinema.Address = request.Address;
            cinema.Description = request.Description;
            cinema.Code = request.Code;
            cinema.NameOfCinema = request.NameOfCinema;
            cinema.Rooms = null;
            cinema.IsActive = true;
            await dbContext.Cinemas.AddRangeAsync(cinema);
            await dbContext.SaveChangesAsync();
            cinema.Rooms = request.request_CreateRooms == null ? null : await roomServices.CreateListRoom(cinema.Id, request.request_CreateRooms);
            dbContext.Update(cinema);
            await dbContext.SaveChangesAsync();
            return cinemaResponseObject.ResponseSuccess("Thêm thông tin rạp phim thành công", cinemaConverter.EntityToDTO(cinema));
        }

        public async Task<ResponseObject<DataResponse_Cinema>> DeleteCinema(Request_UpdateCinema request)
        {
            if (dbContext.Cinemas.Any(x => x.Id == request.Id))
            {
                var cinema = dbContext.Cinemas.Find(request.Id);
                if (cinema.Rooms != null)
                {
                    dbContext.Rooms.RemoveRange(cinema.Rooms);
                }
                dbContext.Cinemas.Remove(cinema);
                await dbContext.SaveChangesAsync();
                return cinemaResponseObject.ResponseSuccess("Xóa rạp phim thành công", cinemaConverter.EntityToDTO(cinema));
            }
            return cinemaResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy rạp phim", null);
        }

        public async Task<ResponseObject<DataResponse_Cinema>> UpdateCinema(Request_UpdateCinema request)
        {
            if (dbContext.Cinemas.Any(x => x.Id == request.Id))
            {
                var cinema = dbContext.Cinemas.Find(request.Id);
                cinema.Address = request.Address;
                cinema.Description = request.Description;
                cinema.Code = request.Code;
                cinema.NameOfCinema = request.NameOfCinema;
                if (cinema.Rooms != null)
                {
                    dbContext.Rooms.RemoveRange(cinema.Rooms);
                }
                dbContext.Cinemas.Update(cinema);
                await dbContext.SaveChangesAsync();
                if (request.request_UpdateRooms != null)
                {
                    var room = await roomServices.CreateListRoom(cinema.Id, request.request_UpdateRooms);
                    cinema.Rooms = room;
                }
                else
                {
                    cinema.Rooms = null;
                }
                dbContext.Cinemas.Update(cinema);
                await dbContext.SaveChangesAsync();
                return cinemaResponseObject.ResponseSuccess("Cập nhật thông tin rạp phim thành công", cinemaConverter.EntityToDTO(cinema));
            }
            return cinemaResponseObject.ResponseError(StatusCodes.Status400BadRequest, "Không tìm thấy rạp phim", null);
        }
    }
}
