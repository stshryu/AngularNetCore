using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoServiceApi.Models.RestaurantModel
{
  public class Rating
  {
    /// <summary>
    /// Enum specifying the ratings available to award a restaurant
    /// </summary>
    public enum Ratings { VeryBad=-2, Bad=-1, Neutral=0, Good=1, VeryGood=2, NotRated=3 }

    /// <summary>
    /// The specified rating for a restaurant
    /// </summary>
    public Ratings RestaurantRating { get; set; } = Ratings.NotRated;
  }
}
