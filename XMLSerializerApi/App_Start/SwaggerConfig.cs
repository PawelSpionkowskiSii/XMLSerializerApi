using System.Web.Http;
using WebActivatorEx;
using XMLSerializerApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace XMLSerializerApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "XML Serializer Api");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\XMLSerializerApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi();
        }
    }
}
