using Api_budger.Models.budgers;
using Api_budger.Models.clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_budger.Models.Configurations
{
    public class BudgerConfiguration : IEntityTypeConfiguration<Budger>
    {
        public void Configure(EntityTypeBuilder<Budger> builder)
        {
            builder.ToTable("budger", "budgers");
            builder.HasKey(f => f.BudgerId);
            builder.Property(f => f.BudgerId).HasColumnName("budger_id");
            builder.Property(f => f.BudgerName).HasColumnName("budger");
            builder.Property(f => f.BudgerAmount).HasColumnName("budger_amount");
            builder.Property(f => f.Date).HasColumnName("date");
            builder.Property(f => f.UserId).HasColumnName("user_id");
            builder.Property(f => f.Comment).HasColumnName("comment");
            builder.Property(f => f.BudgerCategoriyId).HasColumnName("budger_category_id");
            builder.HasOne(p => p.User).WithMany(u => u.Buders).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.BudgerCategory).WithMany(u => u.Budgers).HasForeignKey(u => u.BudgerCategoriyId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
