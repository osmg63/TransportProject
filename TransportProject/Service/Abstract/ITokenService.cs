using System.Security.Claims;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Abstract
{
    public interface ITokenService
    {
        object TokenMailGenerator(int userId);
        object TokenAuthenticationGenerator(User apiKullanici);
        bool ValidateToken(string token, int id);
    }
}
