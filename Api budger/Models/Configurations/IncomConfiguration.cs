using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomConfiguration : IEntityTypeConfiguration<Incom>
    {
        public void Configure(EntityTypeBuilder<Incom> builder)
        {
            builder.ToTable("incoms", "budger");
            builder.HasKey(f => f.IncomId);
            builder.Property(f => f.IncomName).HasColumnName("incom");
            builder.Property(f => f.Date).HasColumnName("date");
            builder.Property(f => f.UserId).HasColumnName("user_id");
            builder.Property(f => f.Comment).HasColumnName("comment");
            builder.Property(f => f.IncomeCategoryId).HasColumnName("incom_category_id");
            builder.HasMany(p => p.IncomeCategoryHasFamilies).WithOne(u => u.Incom).HasForeignKey(u => u.IncomCategoryHasFamilyId);
            builder.HasOne(p => p.User).WithMany(u => u.Incoms).HasForeignKey(u => u.UserId);
            builder.HasOne(p => p.IncomeCategory).WithMany(u => u.Incoms).HasForeignKey(u => u.IncomeCategoryId);
        }
    }
}
