using Api_budger.Models.budgers.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class BudgerCategoryConfiguration : IEntityTypeConfiguration<BudgerCategory>
    {
        public void Configure(EntityTypeBuilder<BudgerCategory> builder)
        {
            builder.ToTable("budger_categories", "budgers");
            builder.HasKey(f => f.BudgerCategorieId);
            builder.Property(f => f.BudgerCategorieId).HasColumnName("budger_categoriy_id");
            builder.Property(f => f.BudgerCategoryName).HasColumnName("budger_categoriy");
            builder.HasMany(f => f.BudgerCategoryHasFamilies).WithOne(u => u.BudgerCategory).HasForeignKey(u => u.BudgerCategoryHasFamilyId);
            builder.HasMany(f => f.Budgers).WithOne(u => u.BudgerCategory).HasForeignKey(u => u.BudgerId);
        }
    }
}
