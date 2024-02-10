using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
