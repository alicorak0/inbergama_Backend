using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // Kısıtlama: T, IEntity'den türeyen bir class olmalı.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);
    }
}