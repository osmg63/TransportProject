using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;
using BCrypt.Net;

namespace TransportProject.Service.Concrete
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public ResponseUserDto Add(RequestUserDto user)
        {
            user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password, workFactor: 12);
            var data = _unitOfWork.UserRepository.Add(_mapper.Map<User>(user));
            var result = _mapper.Map<ResponseUserDto>(data);
            return result;
        }

        public bool Delete(int id)
        {
            var data = _unitOfWork.UserRepository.Get(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("User not found.");
            }

            return _unitOfWork.UserRepository.Delete(data);

        }
        public ResponseUserDto UserActiveFalse(int id) {
            var data = _unitOfWork.UserRepository.Get(x => x.Id == id);
            if (data != null)
            {
                data.UserActive = false;
                var result = _mapper.Map<ResponseUserDto>(data);
                _unitOfWork.SaveChangeAsync();
                return result;

            }
            return null;
        }
        public List<ResponseUserDto> GetAll()
        {


            var data = _mapper.Map<List<ResponseUserDto>>(_unitOfWork.UserRepository.GetAll());
            return data;
        }

        public ResponseUserDto GetById(int id)
        {
            var data = _unitOfWork.UserRepository.Get(x => x.Id == id);
            var result = _mapper.Map<ResponseUserDto>(data);
            return result;
        }

        public async Task<ResponseUserDto> Update(RequestUserDto user)
        {

            var data = _unitOfWork.UserRepository.Get(x => x.Id == user.Id);
            if (data != null)
            {
                user.Password = data.Password;
                _mapper.Map(user, data);
                await _unitOfWork.SaveChangeAsync();
                var result = _mapper.Map<ResponseUserDto>(data);
                return  result;
            }
            throw new Exception("Update fail");

        }

        public async Task<bool> ResetPassword(int id, string password,string token)
        {
            var data = _unitOfWork.UserRepository.Get(x => x.Id == id);
            bool isTokenActive = _tokenService.ValidateToken(token,id);
            if (data != null && isTokenActive==true) {
                data.Password = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
              await  _unitOfWork.SaveChangeAsync();
                return true;
            }
            throw new Exception("Invalid or expired token.");
        }
        public Object Login(UserLoginDto user)
        {
            var data = _unitOfWork.UserRepository.Get(x=>x.UserName == user.UserName);
            if (data != null && BCrypt.Net.BCrypt.Verify(user.Password, data.Password)) {           
                    return _tokenService.TokenAuthenticationGenerator(data);                 
            }
            throw new Exception("Incorrect username or password.");
        }
    }
}
