using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.api.Communication.Requests;
using RocketseatAuction.api.Filters;
using RocketseatAuction.api.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.api.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))] // Deixa aqui se todos os endpoints forem usar a autenticação.
    public class OfferController : RocketSeatAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer(
            [FromRoute]int itemId, 
            [FromBody]RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }
    }
}
