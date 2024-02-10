using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
