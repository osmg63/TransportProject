using AutoMapper;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;
using TransportProject.Data.Dtos.OfferDtos;
using TransportProject.Data.Dtos.UserDtos;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Concrete
{
    public class OfferRepository:BaseRepository<Offer>,IOfferRepository
    {
        private readonly TransportDbContext _context;
        private readonly IMapper _mapper;
        public OfferRepository(TransportDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
             _mapper = mapper;
        }

        public List<Offer> GetOffersByUserId(int UserId) { 

            var query = from offer in _context.Offer
                        where offer.UserId == UserId
                        select offer;

            return query.ToList();
        }
        public List<Offer> GetAcceptOffersByUserId(int UserId)
        {
            var query = from offer in _context.Offer
                        where offer.UserId == UserId
                        where offer.IsAccepted == true
                        where offer.IsActive == true
                        select offer;

            return query.ToList();
        }
        public bool GetUserOfferJob(int userId, int jobId)
        {
            var exists = _context.Offer
                                 .Any(offer => offer.UserId == userId && offer.JobId == jobId);
            return exists;
        }
        public List<ResponseGetOfferByJobIdUserDto> GetOfferByJobIdUser(int jobId)
        {
            var query = from offer in _context.Offer
                        where offer.JobId == jobId
                        where offer.IsActive == true
                        join user in _context.Users on offer.UserId equals user.Id

                        select new ResponseGetOfferByJobIdUserDto { 
                            Id = offer.Id,
                            UserId = user.Id,
                            JobId = jobId,
                            UserName= user.Name,
                            UserSurName=user.Surname,
                            UserPhoneNumber=user.PhoneNumber,
                            IsActive=offer.IsActive,
                            IsAccepted=offer.IsAccepted,
                            OfferTime=offer.OfferTime,
                            
                        
                        };

            return query.ToList(); 

        }

    }
}
