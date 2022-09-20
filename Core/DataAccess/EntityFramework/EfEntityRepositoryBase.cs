using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, IContext> : IEntityRepository<TEntity> // kurallar koy
        where TEntity : class, IEntity, new()
        where IContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // bu using farklı bir c# implementasyonu. Using bittiği anda belleği temizliyor.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // eklenecek bir nesne
                context.SaveChanges(); // ve ekle savechanges ile ekle
            }
        }

        public void Delete(TEntity entity)
           

        {
            using (TContext context = new TContext())
            {


                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted; // eklenecek bir nesne
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) // tek data getirir
        {

            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        List<TEntity> IEntityRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                // filtre  null mı ? null ise listele değilsse filtrele

                return filter == null
                                     ? context.Set<TEntity>().ToList()
                                    : context.Set<TEntity>().Where(filter).ToList();

                // filtre  null mı ? null ise listele değilsse filtrele
                // filtre  null mı ? null ise listele değilsse filtrele


            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {


                var updatedEntity = context.Entry(entity); // referansı yakala
                updatedEntity.State = EntityState.Modified; // eklenecek bir nesne
                context.SaveChanges();
            }
        }
    }
}
