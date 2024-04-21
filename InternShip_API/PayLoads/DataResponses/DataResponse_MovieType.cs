using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_MovieType
    {
        public string MovieTypeName { get; set; }
        public IQueryable<DataResponse_Movie>? dataResponse_Movies { get; set; }
    }
}
