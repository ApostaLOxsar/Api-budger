namespace Api_budger.Models.budgers
{
    public class IncomeCategories
    {
        public long IncomCategoryId { get; set; }
        public string? IncomCategory { get; set; }

        public ICollection<Incoms>? Incoms { get; set; }
    }
}
