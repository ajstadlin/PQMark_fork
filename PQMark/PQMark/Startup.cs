using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PQMark.Startup))]
namespace PQMark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
