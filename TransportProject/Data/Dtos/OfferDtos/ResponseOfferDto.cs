using TransportProject.Data.Entities;

namespace TransportProject.Data.Dtos.OfferDtos
{
    public class ResponseOfferDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime OfferTime { get; set; }
    }
}
