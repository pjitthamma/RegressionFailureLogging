using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegressionFailureTracking.Startup))]
namespace RegressionFailureTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
