using TransportProject.Data.Dtos;
using TransportProject.Data.Entities;

namespace TransportProject.Service.Abstract
{
    public interface IOfferService
    {
        RequestOfferDto AddOffer(RequestOfferDto offer);
        List<Offer> GetAllOffer();
        List<Offer> GetOfferByUserId(int id);
        bool OfferDelete(int id);
        Offer ChangeOfferActive(int id);
        Offer ChangeOfferInActive(int id);
        bool OfferAccept(int id);
        List<Offer> GetOfferAcceptByUserId(int id);
    }
}
