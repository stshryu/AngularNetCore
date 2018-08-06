using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoServiceApi.Contracts
{
  public interface IAPIDataSeed
  {
    Dictionary<string, int> SeedDb();
  }
}
