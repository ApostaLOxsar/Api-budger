using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;

namespace Api_budger.Models.clients
{
    public class Family
    {
        public long FamilyId { get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<IncomeCategoryHasFamily>? IncomeCategoryHasFamilies { get; set; }
        public ICollection<BudgerCategoryHasFamily>? BudgerCategoryHasFamilies { get; set; }
    }
}
