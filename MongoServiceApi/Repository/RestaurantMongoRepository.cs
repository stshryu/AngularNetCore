using BlogTestConfiguration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoServiceApi.Contracts;
using MongoServiceApi.Models;
using MongoServiceApi.Models.RestaurantModel;
using System;
using System.Collections.Generic;

namespace MongoServiceApi.Repository
{
  public class RestaurantMongoRepository : BaseMongoRepository<Restaurant>, IRestaurantMongoRepository
  {
    private readonly OptionsConfiguration _config;
    private string _connStr;
    private string _dbName = "BlogTest";
    protected override string CollectionName { get => "BlogRestaurants"; }

    public RestaurantMongoRepository(IOptions<OptionsConfiguration> configuration) : base(configuration)
    {
      // Set configuration value
      _config = configuration.Value;
      // Get connection string from appsettings
      _config.MongoDbOptions.TryGetValue("ConnectionString", out _connStr);
    }

    public IList<Restaurant> GetAllRestaurants()
    {
      throw new NotImplementedException();
    }

    public Restaurant GetRestaurantById(string id)
    {
      return this.GetDb().GetCollection<Restaurant>(CollectionName).Find(restaurant => restaurant.Id == id).FirstOrDefault();
    }

    public IList<Restaurant> GetRestaurantsByDates(DateTime start, DateTime end)
    {
      throw new NotImplementedException();
    }

    public IList<Restaurant> GetRestaurantsByName(string name)
    {
      throw new NotImplementedException();
    }

    public IList<Restaurant> GetRestaurantsByRating(Rating lowerEnd, Rating upperEnd)
    {
      throw new NotImplementedException();
    }

  }
}
