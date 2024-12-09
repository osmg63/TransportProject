namespace TransportProject.Data.Entities
{
    public class Offer
    {
        public int Id { get; set; } 
        public int JobId { get; set; }
        public int UserId {  get; set; }
        public bool IsActive {  get; set; }
        public bool IsAccepted { get; set; }
        public DateTime OfferTime { get; set; }
        public virtual User User { get; set; }
        public virtual Job Job { get; set; }   

    }
}