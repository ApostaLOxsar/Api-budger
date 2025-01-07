using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class Budgers
    {
        public long BudgerId { get; set; }
        public long Budger { get; set; }
        public DateTime Date { get; set; }
        public ICollection<BudgerCategoryHasFamily>? BudgerCategoryHasFamily { get; set; }
    }
}
