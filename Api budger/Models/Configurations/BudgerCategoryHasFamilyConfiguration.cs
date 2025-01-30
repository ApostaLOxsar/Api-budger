using Api_budger.Models.budgers.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class BudgerCategoryHasFamilyConfiguration : IEntityTypeConfiguration<BudgerCategoryHasFamily>
    {
        public void Configure(EntityTypeBuilder<BudgerCategoryHasFamily> builder)
        {
            builder.ToTable("budger_category_has_family", "budgers");
            builder.HasKey(f => f.BudgerCategoryHasFamilyId);
            builder.Property(f => f.BudgerCategoryHasFamilyId).HasColumnName("budger_category_has_family_id");
            builder.Property(f => f.FamilyId).HasColumnName("family_id");
            builder.Property(f => f.BudgerCategoryId).HasColumnName("budger_category_id");
            builder.HasOne(f => f.BudgerCategory).WithMany().HasForeignKey(f => f.BudgerCategoryId);
            builder.HasOne(f => f.Family).WithMany().HasForeignKey(f => f.FamilyId);
        }
    }
}
