using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoServiceApi.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoServiceApi.Controllers
{
  [LocalhostRestriction]
  [Produces("application/json")]
  [Route("api/admin")]
  public class AdminController : Controller
  {
    IAPIDataSeed _mongoDbSeed;

    /// <summary>
    /// Initializes the controller with required data
    /// </summary>
    /// <param name="dbSeed"></param>
    public AdminController(IAPIDataSeed dbSeed)
    {
      _mongoDbSeed = dbSeed;
    }

    /// <summary>
    /// The API result to seed the database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("seed")]
    public IActionResult Seed()
    {
      Dictionary<string, int> status;
      try
      {
        status = _mongoDbSeed.SeedDb();
      }
      catch (TimeoutException)
      {
        return BadRequest("Could not seed data to the specified MongoDB instance because a timed out exception has occured");
      }
      catch(Exception ex)
      {
        return BadRequest($"An exception has occured - {ex.Message}");
      }
      return new JsonResult((status));
    }
  }

  /// <summary>
  /// Prevent access of SeedDb unless called from localhost
  /// </summary>
  public class LocalhostRestrictionAttribute : System.Attribute, IActionFilter
  {
    public void OnActionExecuted(ActionExecutedContext context)
    {
      // Do nothing
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (!string.Equals(context.HttpContext.Request.Host.Host, "localhost", StringComparison.OrdinalIgnoreCase))
        context.Result = new BadRequestObjectResult("The action can be invoked only using localhost");
    }
  }
}
