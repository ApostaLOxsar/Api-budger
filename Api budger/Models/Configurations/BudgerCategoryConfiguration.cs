using Api_budger.Models.budgers.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class BudgerCategoryConfiguration : IEntityTypeConfiguration<BudgerCategory>
    {
        public void Configure(EntityTypeBuilder<BudgerCategory> builder)
        {

        }
    }
}
