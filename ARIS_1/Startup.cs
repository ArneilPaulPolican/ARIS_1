using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARIS_1.Startup))]
namespace ARIS_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
