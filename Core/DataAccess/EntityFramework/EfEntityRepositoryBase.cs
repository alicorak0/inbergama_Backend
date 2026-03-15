using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>             // kurallar koyalım
      where TEntity : class, IEntity, new()                  //IEntityden türemeli
      where TContext : DbContext, new()               // DbContext türünde    olmalı ve newlenebilmeli

    {
        public void Add(TEntity entity)
        { //Ef Core ekleme işlemleri

            using (TContext context = new TContext())
            {  //EntityEntry türünde
                var addedEntity = context.Entry(entity); //state yönetimi
                                                         //       var addedEntity = context.Products.Add(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;

                context.SaveChanges();
            }

        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {  //EntityEntry türünde           

                var deletedEntity = context.Entry(entity);     //state yönetimi
                                                           //       var addedEntity = context.Products.Add(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {                                         //Product.ToList genel hali  .Set                                           // filtreyi veriyorum öyle dön
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }


        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {  //EntityEntry türünde
                var updatedEntity = context.Entry(entity); //state yönetimi
                                                           //       var addedEntity = context.Products.Add(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
