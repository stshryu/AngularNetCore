using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoServiceApi.Models.RestaurantModel;
using System;

namespace MongoServiceApi.Models
{
  public class Restaurant
  {
    /// <summary>
    /// Mongo generated internal ID
    /// </summary>
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId MongoId { get; set; }

    /// <summary>
    /// Unique ID for each restaurant
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Name of the restaurant
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Date of visit
    /// </summary>
    public DateTime VisitDate { get; set; }

    /// <summary>
    /// Restaurant rating from a set enum of ratings
    /// </summary>
    public Rating RestaurantRating { get; set; }

    /// <summary>
    /// Restaurant review and description
    /// </summary>
    public Review RestaurantReview { get; set; }
  }
}
