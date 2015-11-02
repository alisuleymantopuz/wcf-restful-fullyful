using NorthwindApplication.Orm;
using NorthwindApplication.Services.Contracts.Data;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindApplication.Services.Application.Assemblers
{
    public static class CustomerAssembler
    {
        public static IEnumerable<CustomerInfo> CustomerListToCustomerInfoList(this IEnumerable<Customer> customers)
        {
            return customers.Select(customer => new CustomerInfo
            {
                CustomerId = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            }).ToList();
        }

        public static CustomerInfo CustomerToCustomerInfo(this Customer customer)
        {
            var customerInfo = new CustomerInfo();
            customerInfo.CustomerId = customer.CustomerID;
            customerInfo.CompanyName = customer.CompanyName;
            customerInfo.ContactName = customer.ContactName;
            customerInfo.ContactTitle = customer.ContactTitle;
            customerInfo.Address = customer.Address;
            customerInfo.City = customer.City;
            customerInfo.Region = customer.Region;
            customerInfo.PostalCode = customer.PostalCode;
            customerInfo.Country = customer.Country;
            customerInfo.Phone = customer.Phone;
            customerInfo.Fax = customer.Fax;
            return customerInfo;
        }
    }
}