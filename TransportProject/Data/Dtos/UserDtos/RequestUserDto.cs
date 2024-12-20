﻿using TransportProject.Data.Entities;

namespace TransportProject.Data.Dtos.UserDtos
{
    public class RequestUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string PhoneNumber { get; set; }
        public bool UserActive { get; set; }
        public DateTime Created { get; set; }

    }
}