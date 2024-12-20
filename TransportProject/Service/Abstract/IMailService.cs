namespace TransportProject.Service.Abstract;

public interface IMailService
{
    Task SendEmailAsync(string email, string subject, string message);
    Task SendPasswordMailAsync(string userId);

}
