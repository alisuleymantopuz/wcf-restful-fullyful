using NorthwindApplication.Repository.Implementations;
using System;
using System.Configuration;
using System.Net;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;

namespace NorthwindApplication.Services.Contracts.Invokers
{
    public class AuthenticationInvoker : Attribute, IOperationBehavior, IOperationInvoker
    {
        public static ApplicationUserRepository ApplicationUserRepository { get { return new ApplicationUserRepository(); } }

        private IOperationInvoker _invoker;

        #region OperationBehavior

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            _invoker = dispatchOperation.Invoker;
            dispatchOperation.Invoker = this;
        }

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation) { }

        public void Validate(OperationDescription operationDescription) { }

        #endregion

        #region OperationInvoker

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {

            if (Authenticate(ConfigurationSettings.AppSettings["ApplicationServerName"]))
                return _invoker.Invoke(instance, inputs, out outputs);

            outputs = null;
            return null;
        }

        public object[] AllocateInputs() { return _invoker.AllocateInputs(); }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state) { throw new NotSupportedException(); }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result) { throw new NotSupportedException(); }

        public bool IsSynchronous { get { return true; } }

        #endregion

        #region Authentication

        private bool Authenticate(string realm)
        {
            string[] credentials = GetCredentials(WebOperationContext.Current.IncomingRequest.Headers);

            if (credentials != null)
            {
                string username = credentials[0];
                string password = credentials[1];

                var requestUser = ApplicationUserRepository.FirstOrDefault(x => x.Name == username);
                if (requestUser != null && requestUser.Password == password)
                    return true;
            }

            WebOperationContext.Current.OutgoingResponse.Headers["WWW-Authenticate"] = string.Format("Basic realm=\"{0}\"", realm);
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
            return false;
        }

        private string[] GetCredentials(WebHeaderCollection headers)
        {
            string credentials = headers["Authorization"];
            if (credentials != null) credentials = credentials.Trim();

            if (!string.IsNullOrEmpty(credentials))
            {
                try
                {
                    string[] credentialParts = credentials.Split(new char[] { ' ' });
                    if (credentialParts.Length == 2 && credentialParts[0].Equals("basic", StringComparison.OrdinalIgnoreCase))
                    {
                        credentials = Encoding.ASCII.GetString(Convert.FromBase64String(credentialParts[1]));
                        credentialParts = credentials.Split(new char[] { ':' });
                        if (credentialParts.Length == 2) return credentialParts;
                    }
                }
                catch (Exception exception)
                {
                    //Logging
                }
            }

            return null;
        }

        #endregion
    }


}