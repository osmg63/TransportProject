using System.Threading.Tasks;
using TransportProject.Data.Dtos.UserDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Abstract
{
    public interface IUserService
    {
        Task<ResponseUserDto> Add(RequestUserDto user);
        Task<bool> Delete(int id);
        Task<ResponseUserDto> UserActiveFalse(int id);
        Task<List<ResponseUserDto>> GetAll();
        Task<ResponseUserDto> GetById(int id);
        Task<ResponseUserDto> Update(RequestUserDto user);
        Task<bool> ResetPassword(ResetPasswordDto dto);
        Task<Object> Login(UserLoginDto user);
        Task<User> AddPhotoUser(string id, IFormFile file);
        Task<Stream> GetPhotoAsync(string fileName);


    }
}
