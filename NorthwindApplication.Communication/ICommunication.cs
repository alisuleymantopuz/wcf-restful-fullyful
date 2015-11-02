using NorthwindApplication.Communication.Credential;

namespace NorthwindApplication.Communication
{
    public interface ICommunication
    {
        T MakeRequest<T>(string requestUrl, BaseCredential credential);
    }
}
