namespace TransportProject.Data.Dtos
{
    public class MessageBoxDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime LastMesageTime { get; set; }

    }
}
