using System.Data.Entity;
using XMLSerializerApi.Models;

namespace XMLSerializerApi.Configuration.Context
{
    public class SerializerDatabaseContext : DbContext
    {
        public SerializerDatabaseContext() : base("SerializerContextDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SerializerDatabaseContext,
               Migrations.Configuration>("SerializerContextDB"));
        }

        public virtual DbSet<RequestModel> requestModel { get; set; }
    }
}