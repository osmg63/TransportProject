using Microsoft.AspNetCore.Razor.TagHelpers;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Concrete
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly TransportDbContext _context;
        public UserRepository(TransportDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
