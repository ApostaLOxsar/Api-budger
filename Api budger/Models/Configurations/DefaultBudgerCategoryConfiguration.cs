using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class DefaultBudgerCategoryConfiguration : IEntityTypeConfiguration<DefaultBudgerCategory>
    {
        public void Configure(EntityTypeBuilder<DefaultBudgerCategory> builder)
        {
            builder.ToTable("default_budger_category", "budgers");
            builder.HasKey(f => f.DefaultBudgerCategoryId);
            builder.Property(f => f.DefaultBudgerCategoryId).HasColumnName("default_budger_category_id");
            builder.Property(f => f.BudgerCategoryName).HasColumnName("budger_category");
        }
    }
}
