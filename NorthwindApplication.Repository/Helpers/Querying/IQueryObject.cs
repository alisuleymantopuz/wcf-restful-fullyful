using System.Linq.Expressions;

namespace NorthwindApplication.Repository.Helpers.Querying
{
    public interface IQueryObject<TEntity>
    {
        Expression<System.Func<TEntity, bool>> And(Expression<System.Func<TEntity, bool>> query);
        Expression<System.Func<TEntity, bool>> And(IQueryObject<TEntity> queryObject);
        Expression<System.Func<TEntity, bool>> Or(Expression<System.Func<TEntity, bool>> query);
        Expression<System.Func<TEntity, bool>> Or(IQueryObject<TEntity> queryObject);
        Expression<System.Func<TEntity, bool>> Query();
    }
}
