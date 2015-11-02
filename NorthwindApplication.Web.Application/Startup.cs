using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindApplication.Web.Application.Startup))]
namespace NorthwindApplication.Web.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
