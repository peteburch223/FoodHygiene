using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfinityWorks_TechTest.Startup))]
namespace InfinityWorks_TechTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
