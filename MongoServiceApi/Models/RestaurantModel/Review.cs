using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoServiceApi.Models.RestaurantModel
{
  public class Review
  {
    /// <summary>
    /// Description of the restaurant
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// User review of the restaurant
    /// </summary>
    public string UserReview { get; set; }
  }
}
