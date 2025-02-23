﻿using Api_budger.Models.budgers;
using Api_budger.Models.clients;
namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategoryHasFamily
    {
        public long BudgerCategoryHasFamilyId { get; set; }
        public long FamilyId { get; set; }
        public long BudgerCategoryId { get; set; }
        public Family? Family { get; set; }
        public BudgerCategory? BudgerCategory { get; set; }
    }
}
