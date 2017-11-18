using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment3CS3750.Startup))]
namespace Assignment3CS3750
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
