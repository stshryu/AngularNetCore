using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoServiceApi.Contracts
{
  public interface IBaseRepository<T>
  {
    /// <summary>
    /// Get by generic type ID
    /// </summary>
    /// <typeparam name="IdType"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    T GetById<IdType>(IdType id);

    /// <summary>
    /// Drop all documents from collection
    /// </summary>
    void DeleteAll();

    /// <summary>
    /// Drop specified entity from a collection
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);

    /// <summary>
    /// Add an entity to a collection
    /// </summary>
    /// <param name="entity"></param>
    void Add(T entity);

    /// <summary>
    /// Add a list of entities to a collection
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    int Add(IEnumerable<T> entities);

    /// <summary>
    /// Upsert an entity that matches the filter expression to a collection 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="expr"></param>
    void Upsert(T entity, Expression<Func<T, bool>> expr);
  }
}
