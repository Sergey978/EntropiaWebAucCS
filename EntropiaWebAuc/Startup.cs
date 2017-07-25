using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntropiaWebAuc.Startup))]
namespace EntropiaWebAuc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
