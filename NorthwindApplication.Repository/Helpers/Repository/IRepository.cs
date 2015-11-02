using System;
using System.Collections.Generic; 
using System.Linq.Expressions; 

namespace NorthwindApplication.Repository.Helpers.Repository
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity); 
        void Create(IList<T> entities); 
        T Update(T entity);  
        T FirstOrDefault(Expression<Func<T, bool>> clause); 
        IEnumerable<T> Where(Expression<Func<T, bool>> clause); 
        IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector); 
        T First(); 
        IEnumerable<T> All();
    }
}
