using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
