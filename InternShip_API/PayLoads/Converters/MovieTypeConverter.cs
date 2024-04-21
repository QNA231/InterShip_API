using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class MovieTypeConverter
    {
        private readonly AppDbContext dbContext;
        private readonly MovieConverter converter;

        public MovieTypeConverter(AppDbContext dbContext, MovieConverter converter)
        {
            this.dbContext = dbContext;
            this.converter = converter;
        }

        public DataResponse_MovieType EntityToDTO(MovieType movieType)
        {
            return new DataResponse_MovieType()
            {
                MovieTypeName = movieType.MovieTypeName,
                dataResponse_Movies = dbContext.Movies.Where(x => x.MovieTypeId == movieType.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
