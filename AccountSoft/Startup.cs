using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccountSoft.Startup))]
namespace AccountSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
