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
            builder.HasMany(p => p.IncomCategoryHasFamilies).WithOne(u => u.IncomCategory).HasForeignKey(u => u.IncomCategoryId);
            builder.HasMany(p => p.Incoms).WithOne(u => u.IncomeCategory).HasForeignKey(u => u.IncomeCategoryId);
        }
    }
}
