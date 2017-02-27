using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadreManagement.Web.Startup))]
namespace CadreManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
