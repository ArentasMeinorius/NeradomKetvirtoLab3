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
    
    public DefaultController(ITablesService tablesService)
    {
        _tablesService = tablesService;
    }

    /// <summary>
    /// Get all tables
    /// </summary>
    [HttpGet("tables")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Table>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Table> GetTables(Table newTable)
    {
        var tables = _tablesService.GetAllTables();
        if(tables != null) { 
            return new ObjectResult(tables) { StatusCode = StatusCodes.Status201Created }; 
        }
        return NotFound();
    }
}