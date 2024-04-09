using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class CinemaConverter
    {
        private readonly AppDbContext dbContext;
        private readonly RoomConverter converter;

        public CinemaConverter(AppDbContext dbContext, RoomConverter converter)
        {
            this.dbContext = dbContext;
            this.converter = converter;
        }
        public DataResponse_Cinema EntityToDTO (Cinema cinema)
        {
            return new DataResponse_Cinema
            {
                Address = cinema.Address,
                Description = cinema.Description,
                NameOfCinema = cinema.NameOfCinema,
                dataResponse_Rooms = dbContext.Rooms.Where(x => x.CinemaId == cinema.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
