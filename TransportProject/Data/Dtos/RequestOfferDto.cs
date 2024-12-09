using TransportProject.Data.Entities;

namespace TransportProject.Data.Dtos
{
    public class RequestOfferDto
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime OfferTime { get; set; }
    }
}
