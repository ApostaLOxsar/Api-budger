using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class IncomConfiguration : IEntityTypeConfiguration<Incom>
    {
        public void Configure(EntityTypeBuilder<Incom> builder)
        {

        }
    }
}
