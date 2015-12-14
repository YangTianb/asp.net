using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenID.Startup))]
namespace OpenID
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
