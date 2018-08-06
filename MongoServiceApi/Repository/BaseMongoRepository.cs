using BlogTestConfiguration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoServiceApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoServiceApi.Repository
{
  public abstract class BaseMongoRepository<T> : IBaseRepository<T>
  {
    private readonly OptionsConfiguration _config;

    // Name of collection in Mongo
    protected abstract string CollectionName { get; }

    /// <summary>
    /// Returns an instance of a MongoDatabase
    /// </summary>
    /// <returns></returns>
    protected IMongoDatabase GetDb()
    {
      var client = new MongoClient(_config.MongoDbOptions["ConnectionString"]);
      return client.GetDatabase(CollectionName);
    }

    /// <summary>
    /// Constructor for BaseMongoRepository
    /// </summary>
    /// <param name="configuration"></param>
    public BaseMongoRepository(IOptions<OptionsConfiguration> configuration)
    {
      _config = configuration.Value;
    }

    /// <summary>
    /// Add an entity to a collection with type T
    /// </summary>
    /// <param name="entity"></param>
    public void Add(T entity)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Add a list of entities to a collection with type T
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public int Add(IEnumerable<T> entities)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Delete an entity from a collection with type T
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(T entity)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Delete all documents from a collection
    /// </summary>
    public void DeleteAll()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Get by ID type T
    /// </summary>
    /// <typeparam name="IdType"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    public T GetById<IdType>(IdType id)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Upsert into a collection based on a filter expression comparing type T
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="expr"></param>
    public void Upsert(T entity, Expression<Func<T, bool>> expr)
    {
      var collection = this.GetDb().GetCollection<T>(CollectionName);
      collection.ReplaceOne<T>(expr, entity, new UpdateOptions() { IsUpsert = true });
    }
  }
}
