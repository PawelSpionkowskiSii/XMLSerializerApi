using System.Data.Entity.Migrations;

namespace XMLSerializerApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<XMLSerializerApi.Configuration.Context.SerializerDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "XMLSerializer.SerializerContextDB";
        }

        protected override void Seed(XMLSerializerApi.Configuration.Context.SerializerDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
