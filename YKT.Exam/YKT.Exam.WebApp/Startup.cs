using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YKT.Exam.WebApp.Startup))]
namespace YKT.Exam.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
