using NorthwindApplication.Orm;
using NorthwindApplication.Repository.Helpers.Repository;
using System.Collections.Generic;

namespace NorthwindApplication.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomerSalesWithPurchaseMoreThan(decimal amount);
    }
}
