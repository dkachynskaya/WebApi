using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);

        /*TEntity Get(TKey id);
        void Update(TEntity entity);
        void Delete(TKey id);*/
    }
}
