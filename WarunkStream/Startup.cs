using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarunkStream.Startup))]
namespace WarunkStream
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
