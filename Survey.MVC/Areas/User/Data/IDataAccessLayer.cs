using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.MVC.Areas.User.Data
{
    public interface IDataAccessLayer<TEntity>
    {
        TEntity Create(TEntity entity);
        Task<List<TEntity>> GetAll();
        TEntity GetById(int id);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}