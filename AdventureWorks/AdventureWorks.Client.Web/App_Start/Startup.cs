using Microsoft.Owin;
using Owin;
using Xomega.Framework;

// to help OWIN find the Startup class when assembly name has spaces
[assembly: OwinStartup(typeof(AdventureWorks.Client.Web.Startup))]

namespace AdventureWorks.Client.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AppInitializer.Initalize(new WebAppInit());
            app.Use<DIMiddleware>();
            ConfigureAuth(app);
        }
    }
}
