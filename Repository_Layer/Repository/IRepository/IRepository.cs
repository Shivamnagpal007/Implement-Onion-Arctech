using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Repository.IRepository
{  
     public interface IRepository<T> where T : class
        {
            T Get(int Id);
            IEnumerable<T> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = null
             );
            T FirstOrDefault(
                Expression<Func<T, bool>> filter = null,
                string includeProperties = null
                );
            void Add(T entity);
            bool Remove(int Id);
            bool Remove(T entity);
            bool Save();
       }
    
}
