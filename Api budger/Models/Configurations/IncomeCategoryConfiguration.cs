using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomeCategoryConfiguration : IEntityTypeConfiguration<IncomeCategory>
    {
        public void Configure(EntityTypeBuilder<IncomeCategory> builder)
        {

        }
    }
}
