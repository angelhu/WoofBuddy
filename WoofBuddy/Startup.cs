using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WoofBuddy.Startup))]
namespace WoofBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
