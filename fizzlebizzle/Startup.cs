using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fizzlebizzle.Startup))]
namespace fizzlebizzle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
