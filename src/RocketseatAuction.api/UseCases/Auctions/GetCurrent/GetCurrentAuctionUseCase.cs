using RocketseatAuction.api.Contracts;
using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository; 
    public Auction? Execute()
    {
        return _repository.GetCurrent();
    }
}
