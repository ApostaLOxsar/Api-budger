using Api_budger.Models.clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api_budger.Consts;

namespace Api_budger.Models.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles", "clients");
            builder.HasKey(f => f.RoleId);
            builder.Property(f => f.RoleName).HasColumnName("role");
            builder.HasMany(f => f.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);
        }
    }
}
