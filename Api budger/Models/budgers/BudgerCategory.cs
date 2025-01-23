using Api_budger.Models.Abstractions;

namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategory : BudgerCategoryBase
    {
        public long BudgerCategoryId { get; set; }
        public IEnumerable<BudgerCategoryHasFamily>? BudgerCategoryHasFamilies { get; set; }
        public IEnumerable<Budger>? Budgers { get; set; }
    }
}
