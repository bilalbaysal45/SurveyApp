using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Data.Abstract
{
    public interface IDataAccessLayer<TEntity>
    {

        Task<Root<TEntity>> Create(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);
    }
}