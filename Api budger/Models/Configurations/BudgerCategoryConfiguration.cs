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
            builder.HasMany(f => f.Families).WithMany(b => b.BudgerCategories)
                .UsingEntity<BudgerCategoryHasFamily>
                (f => f.HasOne(f => f.Family).WithMany().HasForeignKey(f => f.FamilyId),
                (b => b.HasOne(b => b.BudgerCategory).WithMany().HasForeignKey(b => b.BudgerCategoryId)));
        }
    }
}
