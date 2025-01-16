using Api_budger.Models.Abstractions;

namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategory : BudgerCategoryBase
    {
        public long BudgerCategoryId { get; set; }
        public ICollection<BudgerCategoryHasFamily>? BudgerCategoryHasFamilies { get; set; }
        public ICollection<Budger>? Budgers { get; set; }
    }
}
