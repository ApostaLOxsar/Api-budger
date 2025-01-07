namespace Api_budger.Models.budgers
{
    public class IncomeCategory
    {
        public long IncomCategoryId { get; set; }
        public string? IncomCategory { get; set; }

        public ICollection<Incom>? Incoms { get; set; }
    }
}
