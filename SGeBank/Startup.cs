using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGeBank.Startup))]
namespace SGeBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
