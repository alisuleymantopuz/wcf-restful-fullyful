using System.Configuration; 

namespace NorthwindApplication.Web.Application
{
    public class WebConfiguration
    {
        public string ApplicationServerURL { get { return ConfigurationManager.AppSettings["ApplicationServerURL"]; } }

        public string CredentialUserName { get { return ConfigurationManager.AppSettings["CredentialUserName"]; } }

        public string CredentialPassword { get { return ConfigurationManager.AppSettings["CredentialPassword"]; } }
    }
}