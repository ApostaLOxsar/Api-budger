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

        }
    }
}
