using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tagro.Admin.Startup))]
namespace Tagro.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
