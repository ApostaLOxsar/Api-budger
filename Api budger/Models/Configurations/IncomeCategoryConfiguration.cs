using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomeCategoryConfiguration : IEntityTypeConfiguration<IncomCategory>
    {
        public void Configure(EntityTypeBuilder<IncomCategory> builder)
        {
            builder.ToTable("incom_categories", "budgers");
            builder.HasKey(f => f.IncomCategoryId);
            builder.Property(f => f.IncomCategoryName).HasColumnName("incom_category");
            builder.Property(f => f.IncomCategoryId).HasColumnName("incom_category_id");
            builder.HasMany(f => f.Families).WithMany(i => i.IncomeCategories)
                .UsingEntity<IncomCategoryHasFamily>(
                f => f.HasOne(f => f.Family).WithMany().HasForeignKey(f => f.FamilyId),
                c => c.HasOne(c => c.IncomCategory).WithMany().HasForeignKey(c => c.IncomCategoryId));
        }
    }
}
