using Microsoft.EntityFrameworkCore;
using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.Repositories;

public class RocketseatAuctionDbContext : DbContext // Heritage.
{
    public RocketseatAuctionDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Auction> Auctions { get; set; } // Connection with the Database.
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
