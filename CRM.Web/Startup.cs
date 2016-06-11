using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM.Web.Startup))]
namespace CRM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
