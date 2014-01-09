using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Winter.Web.Startup))]
namespace Winter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
