using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TagroReport.Startup))]
namespace TagroReport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
