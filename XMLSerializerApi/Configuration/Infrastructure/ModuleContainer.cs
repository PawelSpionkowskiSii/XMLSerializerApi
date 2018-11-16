using Autofac;

namespace XMLSerializerApi.Configuration.Infrastructure
{
    public class ModuleContainer
    {
        public static void InitializeModules(ContainerBuilder builder)
        {
            DataStoreModule.Build(builder);
            FileGeneratorModule.Build(builder);
            DatabaseHandlerModule.Build(builder);
        }
    }
}