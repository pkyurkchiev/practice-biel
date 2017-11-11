using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SC.Website.Startup))]
namespace SC.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
