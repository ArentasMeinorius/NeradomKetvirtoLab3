using Microsoft.AspNetCore.Mvc;
using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NeradomKetvirtoLab3.Controllers;

[ApiController]
[Route("[controller]")] // Added to resolve swagger documentation naming conflicts
[SwaggerTag("managing consumables and employees")]
public class ManagerController : ControllerBase
{
    private readonly ITablesService _tablesService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IOrdersService _ordersService;
    private readonly IConsumablesService _consumablesService;
    private readonly IVisitsService _visitsService;

    public ManagerController(
        ITablesService tablesService, 
        IAuthenticationService authenticationService, 
        IOrdersService ordersService,
        IConsumablesService consumablesService,
        IVisitsService visitsService)
    {
        _tablesService = tablesService;
        _authenticationService = authenticationService;
        _ordersService = ordersService;
        _consumablesService = consumablesService;
        _visitsService = visitsService;
    }

    /// <summary>
    /// Edit table information
    /// </summary>
    /// <param name="newTable"></param>
    /// <returns></returns>
    [HttpPut("tables")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Table))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Table> UpdateTable(Table newTable)
    {
        var table = _tablesService.Update(newTable);
        if(table != null) { 
            return new ObjectResult(table) { StatusCode = StatusCodes.Status201Created }; 
        }
        return NotFound();
    }
    
    /// <summary>
    /// Edit consumable information
    /// </summary>
    /// <param name="newConsumable"></param>
    /// <returns></returns>
    [HttpPut("consumables")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Consumable))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Consumable> UpdateConsumable(Consumable newConsumable)
    {
        var consumable = _consumablesService.Update(newConsumable);
        if (consumable != null) {
            return new ObjectResult(consumable) { StatusCode = StatusCodes.Status201Created }; 
        }
        return NotFound();
    }

    /// <summary>
    /// Edit visit information
    /// </summary>
    /// <param name="newVisit"></param>
    /// <returns></returns>
    [HttpPut("visits")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Visit))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Visit> UpdateVisit(Visit newVisit)
    {
        var visit = _visitsService.UpdateVisit(newVisit);
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
    public ActionResult<Order> MarkOrderAsCompleted(Guid orderId)
    {
        var order = _ordersService.MarkOrderAsComplete(orderId);
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
    public ActionResult<Order> DeclineOrder(Guid orderId)
    {
        var order = _ordersService.DeclineOrder(orderId);
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
    public ActionResult<List<Order>> GetOrders(Guid orderId, string searchString, int skip, int limit)
    {
        var orders = _ordersService.GetPaginated(orderId, searchString, skip, limit).ToList();
        if (orders.Count != 0) { return Ok(orders); }
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
    public ActionResult<Order> UpdateOrder(Order newOrder)
    {
        var order = _ordersService.Update(newOrder);
        if (order != null) { 
            return new ObjectResult(order) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Add role to user
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    [HttpPut("role")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> AddRole(Guid userId, string role)
    {
        var user = _authenticationService.AddRole(userId, role);
        if (user != null) { return Ok(); }
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
    public ActionResult<UserWithAuth> Authenticate(UserAuth userAuth)
    {
        var user = _authenticationService.Authenticate(userAuth);
        if (user != null) { return Ok(); }
        return Unauthorized();
    }
}