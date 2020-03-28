using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace EntityFrameworkTrial
{
    interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IList<TEntity> GetAll();
        IList<TEntity> Find(string query);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
                    
    }
}
