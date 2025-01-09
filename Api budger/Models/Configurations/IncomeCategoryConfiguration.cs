using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomeCategoryConfiguration : IEntityTypeConfiguration<IncomeCategory>
    {
        public void Configure(EntityTypeBuilder<IncomeCategory> builder)
        {
            builder.ToTable("incom_categories", "budger");
            builder.HasKey(f => f.IncomCategoryId);
            builder.Property(f => f.IncomCategory).HasColumnName("incom_category");
            builder.Property(f => f.IncomCategoryId).HasColumnName("incom_category_id");
            builder.HasMany(p => p.Incoms).WithOne(u => u.IncomeCategory).HasForeignKey(u => u.IncomId);
        }
    }
}
