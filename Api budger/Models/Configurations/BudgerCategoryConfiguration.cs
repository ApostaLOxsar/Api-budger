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
            builder.HasKey(f => f.BudgerCategoryId);
            builder.Property(f => f.BudgerCategoryId).HasColumnName("budger_categoriy_id");
            builder.Property(f => f.BudgerCategoryName).HasColumnName("budger_categoriy");
            builder.HasMany(f => f.BudgerCategoryHasFamilies).WithOne(u => u.BudgerCategory).HasForeignKey(u => u.BudgerCategoryId);
            builder.HasMany(f => f.Budgers).WithOne(u => u.BudgerCategory).HasForeignKey(u => u.BudgerCategoriyId);
        }
    }
}
