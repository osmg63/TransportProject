namespace TransportProject.Data.Dtos.OfferDtos
{
    public class RequestOfferDto
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime OfferTime { get; set; }
    }
}
