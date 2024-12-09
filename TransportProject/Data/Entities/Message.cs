namespace TransportProject.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual User UserSender { get; set; }
        public int UserSenderId { get; set; }
        public virtual User UserRecipient { get; set; }
        public int UserRecipientId { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
