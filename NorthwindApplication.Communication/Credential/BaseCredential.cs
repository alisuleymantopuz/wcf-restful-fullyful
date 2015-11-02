
using System;
using System.Text;

namespace NorthwindApplication.Communication.Credential
{
    public class BaseCredential
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format("Basic {0}", Encode(Name, Password));
        }

        private string Encode(string name, string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", name, password)));
        }
    }
}
