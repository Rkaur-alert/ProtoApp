using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProtoApp.Startup))]
namespace ProtoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
