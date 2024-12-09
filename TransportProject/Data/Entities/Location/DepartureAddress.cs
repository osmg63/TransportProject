namespace TransportProject.Data.Entities.Location
{
    public class DepartureAddress
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }
        public virtual District District { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        public int DistrictId { get; set; }
        public int NeighborhoodId { get; set; }

    }
}
