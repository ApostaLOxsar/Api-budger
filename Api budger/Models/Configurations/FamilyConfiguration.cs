using Api_budger.Models.clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;

namespace Api_budger.Models.Configurations
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.ToTable("families", "clients");
            builder.HasKey(f => f.FamilyId);
            builder.Property(f => f.FamilyId).HasColumnName("family_id");
            builder.Property(f => f.Name).HasColumnName("famili");
            builder.HasMany(f => f.Users).WithOne(u => u.Family).HasForeignKey(u => u.FamilyId);
            builder.HasMany(i => i.IncomeCategories).WithMany(f => f.Families)
                .UsingEntity<IncomCategoryHasFamily>(
                i => i.HasOne(i => i.IncomCategory).WithMany().HasForeignKey(i => i.IncomCategoryId),
                f => f.HasOne(f => f.Family).WithMany().HasForeignKey(f => f.FamilyId));
            builder.HasMany(i => i.BudgerCategories).WithMany(f => f.Families)
                .UsingEntity<BudgerCategoryHasFamily>(
                i => i.HasOne(i => i.BudgerCategory).WithMany().HasForeignKey(i => i.BudgerCategoryId),
                f => f.HasOne(f => f.Family).WithMany().HasForeignKey(f => f.FamilyId));
        }
    }
}
