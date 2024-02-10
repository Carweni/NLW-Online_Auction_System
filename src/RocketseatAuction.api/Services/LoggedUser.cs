using RocketseatAuction.api.Contracts;
using RocketseatAuction.api.Entities;

namespace RocketseatAuction.api.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAcessor;
    private readonly IUserRepository _repository;

    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAcessor = httpContext;
        _repository = repository;
    }
    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return  _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAcessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..]; // Returns from position 7.
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
