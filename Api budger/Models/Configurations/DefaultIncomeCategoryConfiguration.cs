﻿using Api_budger.Models.budgers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Models.Configurations
{
    public class DefaultIncomeCategoryConfiguration : IEntityTypeConfiguration<DefaultIncomeCategory>
    {
        public void Configure(EntityTypeBuilder<DefaultIncomeCategory> builder)
        {

        }
    }
}
