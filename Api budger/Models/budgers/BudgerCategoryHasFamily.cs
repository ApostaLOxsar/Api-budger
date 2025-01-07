using Api_budger.Models.budgers;
using Api_budger.Models.clients;
namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategoryHasFamily
    {
        public long BudgerCategoryHasFamilyId { get; set; }
        public long FamilyId { get; set; }
        public long BudgerId { get; set; }
    }
}
