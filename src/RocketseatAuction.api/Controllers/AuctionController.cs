using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.api.Entities;
using RocketseatAuction.api.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.api.Controllers;

//[Route("[controller]")] //[Route("api/[controller]")]
public class AuctionController : RocketSeatAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var result = useCase.Execute();

        if(result is null)
            return NoContent();

        return Ok(result);
    }

    /* [HttpGet] => vai dar erro, pois não pode dois endpoint no mesmo controller.
    [HttpPut] //ou [HttpGet("test")]
    public IActionResult Test()
    {
        return NotFound("oh, no");*/
}

