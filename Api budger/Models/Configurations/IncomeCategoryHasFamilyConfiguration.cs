using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomeCategoryHasFamilyConfiguration : IEntityTypeConfiguration<IncomeCategoryHasFamily>
    {
        public void Configure(EntityTypeBuilder<IncomeCategoryHasFamily> builder)
        {

        }
    }
}
