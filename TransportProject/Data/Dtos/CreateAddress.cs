using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Dtos
{
    public class CreateAddress
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }
    }
}
