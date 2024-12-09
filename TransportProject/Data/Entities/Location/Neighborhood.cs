namespace TransportProject.Data.Entities.Location
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string NeighborhoodName { get; set; }
        public string PostalCode { get; set; }
        public virtual District District { get; set; }
        public int? DistrictId { get; set; }
    }
}
