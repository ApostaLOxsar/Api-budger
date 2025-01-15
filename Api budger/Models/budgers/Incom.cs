using Api_budger.Models.Abstractions;
using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class Incom : IncomBase
    {
        public long IncomId { get; set; }
        public DateTime Date { get; set; }
        public long IncomeCategoryId { get; set; }
        public User? User { get; set; }
        public IncomCategory? IncomeCategory { get; set; }
        public ICollection<IncomCategoryHasFamily>? IncomeCategoryHasFamilies { get; set; }
    }
}
