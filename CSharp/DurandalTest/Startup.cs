using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DurandalTest.Startup))]
namespace DurandalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
