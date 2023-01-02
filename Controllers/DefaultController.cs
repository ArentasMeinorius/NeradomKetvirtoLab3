using Microsoft.AspNetCore.Mvc;
using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NeradomKetvirtoLab3.Controllers;

[ApiController]
[Route("[controller]")] // Added to resolve swagger documentation naming conflicts
public class DefaultController : ControllerBase
{
    private readonly ITablesService _tablesService;
    private readonly IOrdersService _ordersService;
    private readonly IVisitsService _visitsService;
    private readonly IConsumablesService _consumablesService;

    public DefaultController(
        ITablesService tablesService, 
        IOrdersService ordersService,
        IVisitsService visitsService,
        IConsumablesService consumablesService)
    {
        _tablesService = tablesService;
        _ordersService = ordersService;
        _visitsService = visitsService;
        _consumablesService = consumablesService;
    }

    /// <summary>
    /// Add comment to order and mark as completed
    /// </summary>
    [HttpPost("orders/comment")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> AddCommentOrder(Guid orderId, string comment)
    {
        var order = await _ordersService.AddComment(orderId, comment);
        if (order != null) { return Ok(order); }
        return NotFound();
    }

    /// <summary>
    /// Add discount to order
    /// </summary>
    [HttpPost("orders/addDiscount")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> AddDiscount(Guid orderId, Discounts discount)
    {
        var order = await _ordersService.AddDiscount(orderId, discount);
        if (order != null) { return Ok(order); }
        return NotFound();
    }

    /// <summary>
    /// Add new order
    /// </summary>
    [HttpPost("orders")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> AddOrder(Order newOrder)
    {
        var order = await _ordersService.AddOrder(newOrder);
        if (order != null)
        {
            return new ObjectResult(order) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Add new visit
    /// </summary>
    [HttpPost("visits")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Visit))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Visit>> AddVisit(Visit newVisit)
    {
        var visit = await _visitsService.AddVisit(newVisit);
        if (visit != null)
        {
            return new ObjectResult(visit) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Get receipt for visit
    /// </summary>
    [HttpGet("/receipt/{visitId}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(decimal))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<decimal>> CalculateReceipt(Guid visitId)
    {
        var receipt = await _visitsService.CalculateReceipt(visitId);
        if (receipt != null)
        {
            return new ObjectResult(receipt) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Delete order
    /// </summary>
    [HttpDelete("/orders")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> DeleteOrder(Guid orderId)
    {
        var order = await _ordersService.DeleteOrder(orderId);
        if (order != null)
        {
            return new ObjectResult(order) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Delete visit
    /// </summary>
    [HttpDelete("/visits")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Visit))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Visit>> DeleteVisit(Guid visitId)
    {
        var visit = await _visitsService.DeleteVisit(visitId);
        if (visit != null)
        {
            return new ObjectResult(visit) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Get all consumables
    /// </summary>
    [HttpGet("consumables")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Consumable>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Consumable>>> GetConsumables()
    {
        var consumables = await _consumablesService.GetAllConsumables();
        if (consumables != null)
        {
            return new ObjectResult(consumables) { StatusCode = StatusCodes.Status201Created };
        }
        return NotFound();
    }

    /// <summary>
    /// Get all tables
    /// </summary>
    [HttpGet("tables")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Table>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Table>>> GetTables()
    {
        var tables = await _tablesService.GetAllTables();
        if(tables != null) { 
            return new ObjectResult(tables) { StatusCode = StatusCodes.Status201Created }; 
        }
        return NotFound();
    }
}