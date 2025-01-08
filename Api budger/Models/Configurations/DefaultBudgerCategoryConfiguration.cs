using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class DefaultBudgerCategoryConfiguration : IEntityTypeConfiguration<DefaultBudgerCategory>
    {
        public void Configure(EntityTypeBuilder<DefaultBudgerCategory> builder)
        {

        }
    }
}
