using MongoDB.Driver;
using MongoServiceApi.Models;
using MongoServiceApi.Models.RestaurantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoServiceApi.Contracts
{
  public interface IRestaurantMongoRepository: IBaseRepository<Restaurant>
  { 
    /// <summary>
    /// Gets all restaurants in database
    /// </summary>
    /// <returns></returns>
    IList<Restaurant> GetAllRestaurants();

    /// <summary>
    /// Get specific restaurant by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Restaurant GetRestaurantById(string id);

    /// <summary>
    /// Get a collection of restaurants by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IList<Restaurant> GetRestaurantsByName(string name);

    /// <summary>
    /// Get restaurants visited within the dates
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    IList<Restaurant> GetRestaurantsByDates(DateTime start, DateTime end);

    /// <summary>
    /// Gets all restaurants within a rating scale
    /// </summary>
    /// <param name="lowerEnd"></param>
    /// <param name="upperEnd"></param>
    /// <returns></returns>
    IList<Restaurant> GetRestaurantsByRating(Rating lowerEnd, Rating upperEnd);
  }
}
