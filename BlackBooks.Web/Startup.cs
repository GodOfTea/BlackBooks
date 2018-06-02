using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackBooks.Web.Startup))]
namespace BlackBooks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
