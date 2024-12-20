using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Dtos.AddressDtos
{
    public class DistrictResponseDto
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }

    }
}
