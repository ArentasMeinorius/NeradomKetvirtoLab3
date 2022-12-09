using Microsoft.AspNetCore.Mvc;
using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Repositories;

namespace EFCoreInMemoryDbDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    readonly IAuthorRepository _authorRepository;
    public AuthorController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    [HttpGet]
    public ActionResult<List<Author>> Get()
    {
        return Ok(_authorRepository.GetAuthors());
    }
}