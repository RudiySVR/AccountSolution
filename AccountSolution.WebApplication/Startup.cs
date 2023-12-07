using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccountSolution.WebApplication.Startup))]
namespace AccountSolution.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
