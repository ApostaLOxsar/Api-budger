using Api_budger.Models.Abstractions;
using Api_budger.Models.clients;

namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategory : BudgerCategoryBase
    {
        public long BudgerCategoryId { get; set; }
        public IEnumerable<Family>? Families { get; set; }
        public IEnumerable<Budger>? Budgers { get; set; }
    }
}
