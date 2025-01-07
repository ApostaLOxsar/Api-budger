namespace Api_budger.Models.budgers
{
    public class Incom
    {
        public long IncomId { get; set; }
        public long IncomName { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public long IncomeCategoryId { get; set; }
        public ICollection<IncomeCategoryHasFamily>? IncomeCategoryHasFamilies { get; set; }
    }
}
