using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class Budger
    {
        public long BudgerId { get; set; }
        public long BudgerName { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public long UserId { get; set; }
        public long BudgerCategoriyId { get; set; }
        public User? User { get; set; }
        public BudgerCategory? BudgerCategory { get; set; }
        public ICollection<BudgerCategoryHasFamily>? BudgerCategoryHasFamilies { get; set; }
    }
}
