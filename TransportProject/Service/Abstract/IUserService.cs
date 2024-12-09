using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Abstract
{
    public interface IUserService
    {
        ResponseUserDto Add(RequestUserDto user);
        Boolean Delete(int id);
        Task<ResponseUserDto> Update(RequestUserDto user);
       Task<bool> ResetPassword(int id, string password, string token);
        ResponseUserDto GetById(int id);
        List<ResponseUserDto> GetAll();
        ResponseUserDto UserActiveFalse(int id);
        Object Login(UserLoginDto user);


    }
}
