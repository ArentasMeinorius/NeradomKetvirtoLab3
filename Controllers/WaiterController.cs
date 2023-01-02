using Microsoft.AspNetCore.Mvc;
using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NeradomKetvirtoLab3.Controllers;

[ApiController]
[Route("[controller]")] // Added to resolve swagger documentation naming conflicts
[SwaggerTag("managing payments and tables")]
public class WaiterController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IOrdersService _ordersService;
    private readonly IVisitsService _visitsService;

    public WaiterController(
        IAuthenticationService authenticationService, 
        IOrdersService ordersService,
        IVisitsService visitsService)
    {
        _authenticationService = authenticationService;
        _ordersService = ordersService;
        _visitsService = visitsService;
    }
    
    /// <summary>
    /// Edit visit information
    /// </summary>
    /// <param name="newVisit"></param>
    /// <returns></returns>
    [HttpPut("visits")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Visit))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Visit>> UpdateVisit(Visit newVisit)
    {
        var visit = await _visitsService.UpdateVisit(newVisit);
        if (visit != null) { 
            return new ObjectResult(visit) { StatusCode = StatusCodes.Status201Created }; 
        }
        return NotFound();
    }
    
    /// <summary>
    /// Mark order as complete
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpPost("orders/markComplete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Table))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> MarkOrderAsCompleted(Guid orderId)
    {
        var order = await _ordersService.MarkOrderAsComplete(orderId);
        if (order != null) { return Ok(); }
        return NotFound();
    }

    /// <summary>
    /// Decline an order
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpPost("orders/decline")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> DeclineOrder(Guid orderId)
    {
        var order = await _ordersService.DeclineOrder(orderId);
        if (order != null) { return Ok(); }
        return NotFound();
    }

    /// <summary>
    /// Get order by query
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="searchString"></param>
    /// <param name="skip"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    [HttpGet("orders")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<Order>>> GetOrders(Guid orderId, string searchString, int skip, int limit)
    {
        var orders = await _ordersService.GetPaginated(orderId, searchString, skip, limit);
        if (orders.Count() != 0) { return Ok(orders.ToList()); }
        return BadRequest();
    }
    
    /// <summary>
    /// Edit order information
    /// </summary>
    /// <param name="newOrder"></param>
    /// <returns></returns>
    [HttpPut("orders")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> UpdateOrder(Order newOrder)
    {
        var order = await _ordersService.Update(newOrder);
        if (order != null) { 
            return new ObjectResult(order) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }
    
    /// <summary>
    /// Authenticates POS system user
    /// </summary>
    /// <param name="userAuth"></param>
    /// <returns></returns>
    [HttpPost("authenticate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserWithAuth))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserWithAuth>> Authenticate(UserAuth userAuth)
    {
        var user = await _authenticationService.Authenticate(userAuth);
        if (user != null) { return Ok(); }
        return Unauthorized();
    }
}