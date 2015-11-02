using NorthwindApplication.Orm;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindApplication.Repository.Implementations
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public static NorthwindEntities DbContext = ContextHelper.GetContext;

        public ApplicationUser Create(ApplicationUser entity)
        {
            DbContext.ApplicationUsers.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Create(IList<ApplicationUser> entities)
        {
            DbContext.ApplicationUsers.AddRange(entities);
            DbContext.SaveChanges();
        }

        public ApplicationUser Update(ApplicationUser entity)
        {
            DbContext.ApplicationUsers.AddOrUpdate(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public ApplicationUser FirstOrDefault(Expression<Func<ApplicationUser, bool>> clause)
        {
            return DbContext.ApplicationUsers.FirstOrDefault(clause);
        }

        public IEnumerable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> clause)
        {
            return DbContext.ApplicationUsers.Where(clause);
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<ApplicationUser, TResult>> selector)
        {
            return DbContext.ApplicationUsers.Select(selector);
        }

        public ApplicationUser First()
        {
            return DbContext.ApplicationUsers.First();
        }

        public IEnumerable<ApplicationUser> All()
        {
            return DbContext.ApplicationUsers.ToList();
        }
    }
}
