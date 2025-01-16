using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomeCategoryHasFamilyConfiguration : IEntityTypeConfiguration<IncomCategoryHasFamily>
    {
        public void Configure(EntityTypeBuilder<IncomCategoryHasFamily> builder)
        {
            builder.ToTable("incom_category_has_family", "budgers");
            builder.HasKey(f => f.IncomCategoryHasFamilyId);
            builder.Property(f => f.IncomCategoryHasFamilyId).HasColumnName("incom_category_has_family_id");
            builder.Property(f => f.FamilyId).HasColumnName("family_id");
            builder.Property(f => f.IncomCategoryId).HasColumnName("incom_category_id");
            builder.HasOne(f => f.IncomCategory).WithMany(u => u.IncomCategoryHasFamilies).HasForeignKey(u => u.IncomCategoryId);
            builder.HasOne(f => f.Family).WithMany(u => u.IncomeCategoryHasFamilies).HasForeignKey(u => u.FamilyId);
        }
    }
}
