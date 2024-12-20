using System.Text;
using System.Net;
using System.Net.Mail;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Service.Abstract;

namespace TransportProject.Service.Concrete
{
    public class MailService:IMailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public MailService(IUnitOfWork unitOfWork,ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "transportiletisim@gmail.com";
            var appPassword = "lqxi knpg cdqa plvm"; 

            var client = new SmtpClient("smtp.gmail.com", 587) 
            {
                EnableSsl = true, // SSL/TLS'yi etkinleştir
                Credentials = new NetworkCredential(mail, appPassword) 
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(mail),
                To = { email },
                Subject = subject,
                Body = message,
                IsBodyHtml= true
            };
            

            return client.SendMailAsync(mailMessage);
        }



        public async Task SendPasswordMailAsync(string userId)
        {
            var token=_tokenService.TokenMailGenerator(Convert.ToInt32(userId));
            // E-posta içeriği oluşturuluyor
            StringBuilder mail = new();
            


            // URL'yi string interpolasyonu ile oluşturuyoruz
            mail.AppendLine("Merhaba,<br> Eğer yeni şifre talebinde bulunduysanız, " +
                "aşağıdaki linkten yeni şifre talebinde bulunabilirsiniz.<br>" +
                $"<a href='https://localhost:44377/api/User/Mail-Reset/{userId}/{token}'> https://localhost:44377/api/User/Mail-Reset/{userId}/{token} Yeni şifre talebi için tıklayınız...</a></strong><br><br>" +
                "<span style=\"font-size:12px;\">NOT: Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>" +
                "Saygılarımızla...<br><br><br>HO - Transport A.Ş.");

            // Kullanıcının e-posta adresini almak
            var user = await _unitOfWork.UserRepository.Get(x => x.Id == Convert.ToInt32(userId));

            if (user != null)
            {
                // E-posta gönderimi
                await SendEmailAsync(user.Email, "Şifre Yenileme", mail.ToString());
            }
            else
            {
                // Kullanıcı bulunamazsa hata mesajı yazdırabilir veya başka bir işlem yapabilirsiniz
                throw new Exception("Kullanıcı bulunamadı.");
            }
        }



    }
}
