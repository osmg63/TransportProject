using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;
using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Concrete
{
    public class OfferRepository:BaseRepository<Offer>,IOfferRepository
    {
        private readonly TransportDbContext _context;
        public OfferRepository(TransportDbContext context) : base(context)
        {
            _context = context;
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





    }
}
