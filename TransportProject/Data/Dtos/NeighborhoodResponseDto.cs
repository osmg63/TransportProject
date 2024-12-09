using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Dtos
{
    public class NeighborhoodResponseDto
    {
        public int Id { get; set; }
        public string NeighborhoodName { get; set; }
        public string PostalCode { get; set; }
        public int? DistrictId { get; set; }
    }
}
