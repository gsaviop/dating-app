using api.Controllers;
using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.BugController;

public class BugController : BaseApiController
{

    private readonly DataContext _context;

    public BugController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("auth")]
    public ActionResult<string> GetSecret()
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var thing = _context.Users.Find(-1);

        if (thing == null)
        {
            return NotFound();
        }

        return thing;
    }

    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
        var thing = _context.Users.Find(-1);
        var thingToReturn = thing.ToString();

        return thingToReturn;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("Bad request, sorry!");
    }

}
