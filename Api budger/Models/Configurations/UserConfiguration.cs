using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api_budger.Models.clients;

namespace Api_budger.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "clients");
            builder.HasKey(f => f.UserId);
            builder.Property(f => f.TelegramId).HasColumnName("telegram_id");
            builder.Property(f => f.RoleId).HasColumnName("role_id");
            builder.Property(f => f.FamilyId).HasColumnName("family_id");
            builder.Property(f => f.Name).HasColumnName("name");
            builder.Property(f => f.Soname).HasColumnName("soname");
            builder.Property(f => f.PasswordHash).HasColumnName("password_hash");
            builder.HasMany(f => f.Incoms).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.HasOne(f => f.Family).WithMany(u => u.Users).HasForeignKey(u => u.FamilyId);
            builder.HasOne(f => f.Role).WithMany(u => u.Users).HasForeignKey(u => u.RoleId);
            builder.HasMany(f => f.Buders).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        }
    }
}
