namespace TransportProject.Data.Dtos
{
    public class ResponseMessageDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserSenderId { get; set; }
        public int UserRecipientId { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
