using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.api.Contracts;

namespace RocketseatAuction.api.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _repository;

    public AuthenticationUserAttribute(IUserRepository repository) => _repository = repository; 
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exist = _repository.ExistUserWithEmail(email);                                

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("Not valid e-mail");
            }
        }
        catch(Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authentication)) {
            throw new Exception("Token is missing.");
        }

        return authentication["Bearer ".Length..]; // Returns from position 7.
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
