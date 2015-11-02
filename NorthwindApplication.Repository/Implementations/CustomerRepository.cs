using NorthwindApplication.Orm;
using NorthwindApplication.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindApplication.Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        public static NorthwindEntities DbContext = ContextHelper.GetContext;

        #region IRepository
        public Customer Create(Customer entity)
        {
            DbContext.Customers.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Create(IList<Customer> entities)
        {
            DbContext.Customers.AddRange(entities);
            DbContext.SaveChanges();
        }

        public Customer Update(Customer entity)
        {
            DbContext.Customers.AddOrUpdate(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public Customer FirstOrDefault(Expression<Func<Customer, bool>> clause)
        {
            return DbContext.Customers.FirstOrDefault(clause);
        }

        public IEnumerable<Customer> Where(Expression<Func<Customer, bool>> clause)
        {
            return DbContext.Customers.Where(clause);
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<Customer, TResult>> selector)
        {
            return DbContext.Customers.Select(selector);
        }

        public Customer First()
        {
            return DbContext.Customers.First();
        }

        public IEnumerable<Customer> All()
        {
            return DbContext.Customers.ToList();
        }
        #endregion

        public IEnumerable<Customer> GetCustomerSalesWithPurchaseMoreThan(decimal amount)
        {
            var customerSalesQuery = new CustomerSalesQuery();
            return Where(customerSalesQuery.WithPurchasesMoreThan(amount).Query());
        }
    }
}
