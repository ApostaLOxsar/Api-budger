using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class Incom
    {
        public long IncomId { get; set; }
        public long IncomName { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public string? Comment { get; set; }
        public long IncomeCategoryId { get; set; }
        public User? User { get; set; }
        public IncomeCategory? IncomeCategory { get; set; }
        public ICollection<IncomeCategoryHasFamily>? IncomeCategoryHasFamilies { get; set; }
    }
}
