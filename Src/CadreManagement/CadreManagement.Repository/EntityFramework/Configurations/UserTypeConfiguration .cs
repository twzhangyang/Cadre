using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CadreManagement.Domain.User;

namespace CadreManagement.Repository.EntityFramework.Configurations
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
            Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(50);
            Property(m => m.RegisterDateTime)
                .IsRequired();
            Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}