using NorthwindApplication.Communication;
using NorthwindApplication.Communication.Credential;
using NorthwindApplication.Services.Contracts.Data;
using NorthwindApplication.Web.Application.ServiceDefinitions;
using System.Collections.Generic; 
using System.Web.Mvc;

namespace NorthwindApplication.Web.Application.Controllers
{
    public class CustomersController : BaseController
    {
        public static RestCommunication RestCommunication { get { return new RestCommunication(); } }

        public static WebConfiguration WebConfiguration { get { return new WebConfiguration(); } }

        public ViewResult Index()
        {
            var allCustomersOperationUrl = string.Format("{0}/{1}", WebConfiguration.ApplicationServerURL, RestMethods.GetAllCustomers);

            var data = RestCommunication.MakeRequest<IEnumerable<CustomerInfo>>(allCustomersOperationUrl, null);

            return View(data);
        }

        public ViewResult Detail(string customerId)
        {
            var credential = new BaseCredential { Name = WebConfiguration.CredentialUserName, Password = WebConfiguration.CredentialPassword };

            var customerDetail = string.Format("{0}/{1}", WebConfiguration.ApplicationServerURL, string.Format(RestMethods.GetAllCustomersByCustomerId, customerId));

            var customerInfo = RestCommunication.MakeRequest<CustomerInfo>(customerDetail, credential);

            return View(customerInfo);
        }
    }
}