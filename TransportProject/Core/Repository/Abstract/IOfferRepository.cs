using TransportProject.Data.Entities;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IOfferRepository:IBaseRepository<Offer>
    {
        List<Offer> GetOffersByUserId(int UserId);
        List<Offer> GetAcceptOffersByUserId(int UserId);
    }
}
