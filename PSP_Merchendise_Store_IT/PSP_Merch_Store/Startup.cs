using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSP_Merch_Store.Startup))]
namespace PSP_Merch_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
