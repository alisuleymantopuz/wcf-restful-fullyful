using NorthwindApplication.Repository.Implementations;
using NorthwindApplication.Services.Application.Assemblers;
using NorthwindApplication.Services.Contracts.Data;
using NorthwindApplication.Services.Contracts.Service.Rest;
using System.Collections.Generic;

namespace NorthwindApplication.Services.Application
{
    public class CustomerRestfulService : ICustomerRestfulService
    {
        public CustomerRepository CustomerRepository { get; private set; }

        public CustomerRestfulService()
        {
            CustomerRepository = new CustomerRepository();
        }

        public IEnumerable<CustomerInfo> CustomerList()
        {
            var customers = CustomerRepository.All();

            return customers.CustomerListToCustomerInfoList();
        }


        public CustomerInfo CustomerById(string customerId)
        {
            var customers = CustomerRepository.FirstOrDefault(x => x.CustomerID == customerId);

            return customers.CustomerToCustomerInfo();
        }
    }
}
