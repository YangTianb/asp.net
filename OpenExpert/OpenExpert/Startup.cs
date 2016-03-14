using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenExpert.Startup))]
namespace OpenExpert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
