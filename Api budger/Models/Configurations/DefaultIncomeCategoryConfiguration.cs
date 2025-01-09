using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class DefaultIncomeCategoryConfiguration : IEntityTypeConfiguration<DefaultIncomeCategory>
    {
        public void Configure(EntityTypeBuilder<DefaultIncomeCategory> builder)
        {
            builder.ToTable("default_incom_category", "budgers");
            builder.HasKey(f => f.DefaultIncomCategoryId);
            builder.Property(f => f.DefaultIncomCategoryId).HasColumnName("default_incom_category_id");
            builder.Property(f => f.IncomCategoryName).HasColumnName("incom_category");
        }
    }
}
