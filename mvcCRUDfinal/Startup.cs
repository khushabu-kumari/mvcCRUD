using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcCRUDfinal.Startup))]
namespace mvcCRUDfinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
