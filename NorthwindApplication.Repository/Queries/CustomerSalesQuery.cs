﻿using NorthwindApplication.Orm;
using NorthwindApplication.Repository.Helpers.Querying;
using System.Linq;

namespace NorthwindApplication.Repository.Queries
{
    public class CustomerSalesQuery : QueryObject<Customer>
    {
        public CustomerSalesQuery WithPurchasesMoreThan(decimal amount)
        {
            And(x => x.Orders.SelectMany(y => y.Order_Details)
                .Sum(z => z.UnitPrice * z.Quantity) > amount);

            return this;
        }

        public CustomerSalesQuery WithQuantitiesMoreThan(decimal quantity)
        {
            And(x => x.Orders.SelectMany(y => y.Order_Details)
                .Sum(z => z.Quantity) > quantity);

            return this;
        }
    }
}
