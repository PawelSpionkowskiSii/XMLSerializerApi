using System.Web.Http;
using System.Web.Routing;
using XMLSerializerApi.App_Start;
using XMLSerializerApi.Configuration.Context;

namespace XMLSerializerApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Run();

            RouteTable.Routes.RouteExistingFiles = true;
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            AutoMapperConfig.Initialize();
            SerializerDatabaseContext con = new SerializerDatabaseContext();
            con.Database.Initialize(true);
            con.Database.CreateIfNotExists();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
