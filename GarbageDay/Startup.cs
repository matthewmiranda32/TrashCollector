using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarbageDay.Startup))]
namespace GarbageDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
