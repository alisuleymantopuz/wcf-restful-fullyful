using NorthwindApplication.Services.Contracts.Data;
using NorthwindApplication.Services.Contracts.Invokers;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace NorthwindApplication.Services.Contracts.Service.Rest
{
    [ServiceContract]
    public interface ICustomerRestfulService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAllCustomers/")]
        IEnumerable<CustomerInfo> CustomerList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCustomerById/{customerId}")]
        [AuthenticationInvoker]
        CustomerInfo CustomerById(string customerId);
    }
}
