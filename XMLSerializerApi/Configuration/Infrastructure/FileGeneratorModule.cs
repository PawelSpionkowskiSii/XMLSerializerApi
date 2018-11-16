using Autofac;
using XMLSerializerApi.Generator.File;

namespace XMLSerializerApi.Configuration.Infrastructure
{
    public class FileGeneratorModule
    {
        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterType<FileGenerator>()
               .As<IFileGenerator>()
               .InstancePerRequest();
        }
    }
}