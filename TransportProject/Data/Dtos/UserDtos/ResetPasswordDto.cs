namespace TransportProject.Data.Dtos.UserDtos
{
    public class ResetPasswordDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
