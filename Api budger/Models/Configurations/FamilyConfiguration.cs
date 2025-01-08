using Api_budger.Models.clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.ToTable("families");
            builder.HasKey(f => f.FamilyId);
            builder.Property(f => f.FamilyId).HasColumnName("family_id");
            builder.Property(f => f.Name).HasColumnName("famili");

        }
    }
}
