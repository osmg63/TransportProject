using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Dtos
{
    public class ResponseJobDto
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobPrice { get; set; }
        public DateTime JobDate { get; set; }
        public string Photo { get; set; }
        public int UserId { get; set; }

        public int DepartureAddressId { get; set; }

        public int DestinationAddressId { get; set; }
    }
}
