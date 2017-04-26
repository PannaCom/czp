using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comzipato.Startup))]
namespace comzipato
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
