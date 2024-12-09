using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TransportProject.Data.Entities;
using TransportProject.Security;

namespace TransportProject.Service.Concrete
{
    public class TokenService
    {
        private readonly ConfigJwt _configJwt;

        public TokenService(IOptions<ConfigJwt> configJwt)
        {
            _configJwt = configJwt.Value;
        }

        private object TokenGenerator(IEnumerable<Claim> claims,DateTime expiration)
        {

            if (_configJwt.Key == null)
            {
                throw new ArgumentNullException("Key değeri null olamaz");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configJwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                _configJwt.Issuer,
                _configJwt.Audience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );


            return new JwtSecurityTokenHandler().WriteToken(token);



        }



        public object TokenMailGenerator(int userId)
        {

            var claimDizisi = new[]
            {
                new Claim("reset_password","true"),
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userId))
            };
            DateTime expires= DateTime.Now.AddMinutes(1);
            var token=TokenGenerator(claimDizisi, expires);
            return token;

        }
        public object TokenAuthenticationGenerator(User apiKullanici)
        {
            var claimDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,apiKullanici.UserName),
                new Claim(ClaimTypes.Role,apiKullanici.UserType)
            };
            DateTime expires = DateTime.Now.AddMinutes(10);
            var token = TokenGenerator(claimDizisi, expires);
            return token;
        }
        public bool ValidateToken(string token,int id)
        {
            if (_configJwt.Key == null)
            {
                throw new ArgumentNullException("Key değeri null olamaz");
            }

            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configJwt.Key));
                var tokenHandler = new JwtSecurityTokenHandler();

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configJwt.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _configJwt.Audience,
                    ValidateLifetime = true, 
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                var resetPasswordClaim = principal.FindFirst("reset_password");
                var x = principal.FindFirst(ClaimTypes.NameIdentifier);

                if (resetPasswordClaim != null && resetPasswordClaim.Value == "true" && x.Value.Equals(Convert.ToString(id)))
                {
                    return true; 
                }
             

                return false;
            }
            catch (SecurityTokenExpiredException)
            {
                return false; 
            }
            catch (Exception ex)
            {

                return false; 
            }
        }




    }
}
