using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechShopWebsite.Startup))]
namespace TechShopWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
