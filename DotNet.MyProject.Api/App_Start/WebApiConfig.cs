using System.Web.Http;

namespace DotNet.MyProject.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            AutofacConfig.Register();
            FilterConfig.RegisterGlobalFilters(config.Filters);
            RouteConfig.Register(config);
        }
    }
}