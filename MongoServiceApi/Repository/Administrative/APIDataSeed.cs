using BlogTestConfiguration;
using Microsoft.Extensions.Options;
using MongoServiceApi.Contracts;
using MongoServiceApi.Models;
using MongoServiceApi.Models.RestaurantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoServiceApi.Repository.Administrative
{
  public class APIDataSeed : IAPIDataSeed
  {
    private readonly OptionsConfiguration _config;
    private readonly IRestaurantMongoRepository _restaurantRepo;
    private Random gen = new Random();

    public APIDataSeed(IOptions<OptionsConfiguration> configuration, IRestaurantMongoRepository restaurantRepo)
    {
      _config = configuration.Value;
      _restaurantRepo = restaurantRepo;
    }

    /// <summary>
    /// Seed the database in vagrant
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, int> SeedDb()
    {
      List<Restaurant> DataSeed = new List<Restaurant>();
      foreach (var i in Enumerable.Range(0, 10))
      {
        // Creating the random dataset to seed Mongo With
        Restaurant restaurant = new Restaurant();
        Rating rating = new Rating();
        Review review = new Review();
        // Initialize the Ratings object with RestaurantRating
        rating.RestaurantRating = RandomEnumValue<Rating.Ratings>();
        // Initialize the Review object with both Description and UserReview
        review.Description = "Description of restaurant goes here blah blah blah";
        review.UserReview = "Review of restaurant blah blah my name is edward blah blah food blah blog";
        // Initialize the rest of the restaurant
        restaurant.Id = i.ToString();
        restaurant.Name = $"restaurant-{i}";
        restaurant.VisitDate = RandomDay();
        restaurant.RestaurantRating = rating;
        restaurant.RestaurantReview = review;
        // Add completed restaurant to DataSeed
        DataSeed.Add(restaurant);
      }
      // Upsert data into Mongo if records don't exist
      foreach (var restaurant in DataSeed)
      {
        _restaurantRepo.Upsert(restaurant, res => res.Id == restaurant.Id);
      }

      return new Dictionary<string, int>()
      {
        { "Restaurants Added", DataSeed.Count }
      };
    }

    /// <summary>
    /// Initialize a random day within a start date
    /// </summary>
    /// <returns></returns>
    private DateTime RandomDay()
    {
      DateTime start = new DateTime(2015, 1, 1);
      int range = (DateTime.Today - start).Days;
      return start.AddDays(gen.Next(range));
    }

    /// <summary>
    /// Return a random rating
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static T RandomEnumValue<T>()
    {
      var v = Enum.GetValues(typeof(T));
      return (T)v.GetValue(new Random().Next(v.Length));
    }
  }
}
