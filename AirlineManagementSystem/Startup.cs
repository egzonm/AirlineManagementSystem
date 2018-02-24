using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineManagementSystem.Startup))]
namespace AirlineManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
