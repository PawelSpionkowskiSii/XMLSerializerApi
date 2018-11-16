using Autofac;
using XMLSerializerApi.Configuration.Context.DatabaseManager;

namespace XMLSerializerApi.Configuration.Infrastructure
{
    public class DatabaseHandlerModule
    {
        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseHandler>()
               .As<IDatabaseHandler>()
               .InstancePerRequest();
        }
    }
}