using Autofac;
using XMLSerializerApi.Store.Data;

namespace XMLSerializerApi.Configuration.Infrastructure
{
    public class DataStoreModule
    {
        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterType<DataStore>()
               .As<IDataStore>()
               .InstancePerRequest();
        }
    }
}