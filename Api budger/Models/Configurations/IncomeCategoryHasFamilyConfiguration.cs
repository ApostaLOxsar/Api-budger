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
            builder.Property(f => f.FamilyId).HasColumnName("family_id");
            builder.Property(f => f.IncomId).HasColumnName("incom_id");
            builder.HasOne(f => f.Incom).WithMany(u => u.IncomeCategoryHasFamilies).HasForeignKey(u => u.IncomId);
            builder.HasOne(f => f.Family).WithMany(u => u.IncomeCategoryHasFamilies).HasForeignKey(u => u.FamilyId);
        }
    }
}
