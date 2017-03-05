using System.Data.Common;
using System.Data.Entity;
using CadreManagement.Domain.User;
using CadreManagement.Repository.EntityFramework.Configurations;

namespace CadreManagement.Repository.EntityFramework
{
    public class CadreManagementDbContext : DbContext
    {
        public const string ConnectionString = "CadreManagement";

        public CadreManagementDbContext()
            : base(ConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public CadreManagementDbContext(DbConnection connection) : base(connection, true)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Map(m => m.MapInheritedProperties());

            modelBuilder.Configurations
                .Add(new UserTypeConfiguration())
                ;

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

    }
}