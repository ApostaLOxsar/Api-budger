using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.Abstractions;

namespace Api_budger.Models.clients
{
    public class Family : FamilyBase
    {
        public long FamilyId { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<IncomeCategoryHasFamily>? IncomeCategoryHasFamilies { get; set; }
        public ICollection<BudgerCategoryHasFamily>? BudgerCategoryHasFamilies { get; set; }
    }
}
