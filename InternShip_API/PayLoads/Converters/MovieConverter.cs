using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.IO;

namespace InternShip_API.PayLoads.Converters
{
    public class MovieConverter
    {
        private readonly AppDbContext dbContext;
        private readonly ScheduleConverter converter;

        public MovieConverter(AppDbContext dbContext, ScheduleConverter converter)
        {
            this.dbContext = dbContext;
            this.converter = converter;
        }
        public DataResponse_Movie EntityToDTO(Movie movie)
        {
            return new DataResponse_Movie()
            {
                MovieDuration = movie.MovieDuration,
                EndTime = movie.EndTime,
                PremiereDate = movie.PremiereDate,
                Description = movie.Description,
                Director = movie.Director,
                Image = movie.Image,
                HeroImage = movie.HeroImage,
                Language = movie.Language,
                MovieTypeName = dbContext.MovieTypes.SingleOrDefault(x => x.Id == movie.MovieTypeId).MovieTypeName,
                Name = movie.Name,
                RateDescription = dbContext.Rates.SingleOrDefault(x => x.Id == movie.RateId).Description,
                Traler = movie.Traler,
                dataResponse_Schedules = dbContext.Schedules.Where(x => x.MovieId == x.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
