using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class Repository<T>(AppDbContext dbContext) : IRepository<T> where T : BaseEntity
    {
        public   DbSet<T> Table => dbContext.Set<T>();

        public int Add(T entity)
        {
            Table.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsNoTracking().Where(x => x.IsDeleted == false);
        }

        public T GetById(int id)
        {
            return Table.AsNoTracking().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            T result;

            result = Table.AsNoTracking().Where(predicate).FirstOrDefault();
            return result != null && result.IsDeleted == false ? result : null;

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            var result = Table.AsNoTracking().Where(x => x.IsDeleted == false);
            return result.Where(predicate);
        }

        public void Remove(int id)
        {
            T entity = Table.AsNoTracking().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                return;
            }
            TemizleTracking(entity);
            Table.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            var kayit = GetById(entity.Id);
            entity.CreatedDate = kayit.CreatedDate;
            entity.UpdatedDate = kayit.UpdatedDate;
            TemizleTracking(entity);
            Table.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.CreatedDate = GetById(entity.Id).CreatedDate;


            TemizleTracking(entity);
            Table.Update(entity);
            dbContext.SaveChanges();
        }

        //public void Update( T entity)
        //{
        //    var existingEntity = GetById(entity.Id);

        //    if (existingEntity == null)
        //    {
        //        throw new KeyNotFoundException($"Entity with id {entity.Id} not found.");
        //    }

        //    var entry = dbContext.Entry(existingEntity);
        //    entry.CurrentValues.SetValues(entity);

        //    dbContext.SaveChanges();
        //}

        void TemizleTracking(T entity)
        {
            foreach (var item in dbContext.ChangeTracker.Entries())
            {
                if (item.Entity.GetType().Name == entity.GetType().Name &&
                    ((T)(item.Entity)).Id == entity.Id)
                {
                    (item).State = EntityState.Detached;
                    break;
                }

            }
        }
    }
}
