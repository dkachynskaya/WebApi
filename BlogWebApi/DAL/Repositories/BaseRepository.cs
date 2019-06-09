using System;
using System.Collections.Generic;
using System.Linq;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.DAL.Repositories
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        DbContext context;
        DbSet<TEntity> dbSet;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        /*public abstract TEntity Get(TKey id);

        public abstract void Update(TEntity entity);

        public abstract void Delete(TKey id);*/
    }
}
