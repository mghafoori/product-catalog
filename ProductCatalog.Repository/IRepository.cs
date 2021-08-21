using System.Collections.Generic;

namespace ProductCatalog.Repository
{
    public interface IRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey key);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey key);
    }
}
