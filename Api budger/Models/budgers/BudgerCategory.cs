using Api_budger.Models.Abstractions;

namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategory : BudgerCategoryBase
    {
        public long BudgerCategorieId { get; set; }
        public ICollection<Budger>? Budgers { get; set; }
    }
}
