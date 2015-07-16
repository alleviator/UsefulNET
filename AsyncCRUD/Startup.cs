using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsyncCRUD.Startup))]
namespace AsyncCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
