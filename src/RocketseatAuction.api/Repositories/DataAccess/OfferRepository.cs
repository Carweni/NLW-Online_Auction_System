using RocketseatAuction.api.Contracts;
using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    public OfferRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
