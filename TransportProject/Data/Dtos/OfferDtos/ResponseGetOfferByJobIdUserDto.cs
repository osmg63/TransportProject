namespace TransportProject.Data.Dtos.OfferDtos
{
    public class ResponseGetOfferByJobIdUserDto
    {
  
        public int Id { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime OfferTime { get; set; }
    }
}

