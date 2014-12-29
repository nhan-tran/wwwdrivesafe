using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wwwdrivesafe.Startup))]
namespace wwwdrivesafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
