using NorthwindApplication.Communication.Credential;
using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace NorthwindApplication.Communication
{
    public class RestCommunication : ICommunication
    {
        public T MakeRequest<T>(string requestUrl, BaseCredential credential)
        {
            try
            {
                var request = WebRequest.Create(requestUrl) as HttpWebRequest;

                if (request != null && credential != null)
                {
                    request.Headers.Add("Authorization", credential.ToString());
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null && response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                    var jsonSerializer = new DataContractJsonSerializer(typeof(T));

                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());

                    T jsonResponse = (T)objResponse;

                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                //Logging(e)
                return Activator.CreateInstance<T>();
            }
        }

    }
}
