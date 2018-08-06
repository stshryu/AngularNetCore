using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogTestConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoServiceApi.Contracts;
using MongoServiceApi.Models;

namespace MongoServiceApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BlogMongoController : ControllerBase
  {
    // Initialize dependencies
    private readonly OptionsConfiguration _config;
    private IRestaurantMongoRepository _restaurantRepo;

    /// <summary>
    /// Constructor for the controller to access required data
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="restaurantRepo"></param>
    public BlogMongoController(IOptions<OptionsConfiguration> configuration, IRestaurantMongoRepository restaurantRepo)
    {
      _config = configuration.Value;
      _restaurantRepo = restaurantRepo;
    }

    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(string id)
    {
      return _restaurantRepo.GetRestaurantById(id);
    }
  }
}