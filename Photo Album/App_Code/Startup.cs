using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Photo_Album.Startup))]
namespace Photo_Album
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
