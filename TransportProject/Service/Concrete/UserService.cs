using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.Entities;
using TransportProject.Service.Abstract;
using BCrypt.Net;
using TransportProject.Data.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using TransportProject.Data.Validations;
using System.ComponentModel.DataAnnotations;

namespace TransportProject.Service.Concrete
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _logger = logger;

        }

        public async Task<ResponseUserDto> Add(RequestUserDto user)
        {
          
            user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password, workFactor: 12);
            var data = await _unitOfWork.UserRepository.Add(_mapper.Map<User>(user));
            await _unitOfWork.SaveChangeAsync();
            var result = _mapper.Map<ResponseUserDto>(data);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _unitOfWork.UserRepository.Get(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("User not found.");
            }

            return await _unitOfWork.UserRepository.Delete(data);

        }
        public async Task<ResponseUserDto> UserActiveFalse(int id) {
            var data = await _unitOfWork.UserRepository.Get(x => x.Id == id);
            if (data != null)
            {
                data.UserActive = false;
                var result = _mapper.Map<ResponseUserDto>(data);
                await _unitOfWork.SaveChangeAsync();
                return result;

            }
            return null;
        }
        public async Task<List<ResponseUserDto>> GetAll()
        {


            var data = _mapper.Map<List<ResponseUserDto>>(await _unitOfWork.UserRepository.GetAll());
            return data;
        }

        public async Task<ResponseUserDto> GetById(int id)
        {
            var data = await _unitOfWork.UserRepository.Get(x => x.Id == id);
            var result = _mapper.Map<ResponseUserDto>(data);
            return result;
        }

        public async Task<ResponseUserDto> Update(RequestUserDto user)
        {

            var data =await _unitOfWork.UserRepository.Get(x => x.Id == user.Id);
            if (data != null)
            {
                user.Password = data.Password;
                _mapper.Map(user, data);
                await _unitOfWork.SaveChangeAsync();
                var result = _mapper.Map<ResponseUserDto>(data);
                return  result;
            }
            _logger.LogError("Update fail "+ data.UserName);

            throw new Exception("Update fail");

        }

        public async Task<bool> ResetPassword(ResetPasswordDto dto)
        {
            var data = await _unitOfWork.UserRepository.Get(x => x.Id == dto.Id);
            bool isTokenActive = _tokenService.ValidateToken(dto.Token,dto.Id);
            if (data != null && isTokenActive==true) {
                data.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password, workFactor: 12);
              await _unitOfWork.SaveChangeAsync();
                return true;
            }
           _logger.LogError("Invalid or expired token."+ data.UserName);
            throw new Exception("Invalid or expired token.");
        }
        public async Task<Object> Login(UserLoginDto user)
        {
            var data = await _unitOfWork.UserRepository.Get(x=>x.UserName == user.UserName);
            if (data != null && BCrypt.Net.BCrypt.Verify(user.Password, data.Password)) {           
                    return _tokenService.TokenAuthenticationGenerator(data);                 
            }
            _logger.LogError("Incorrect username or password.." + data.UserName);
            throw new Exception("Incorrect username or password.");
        }
    }
}
