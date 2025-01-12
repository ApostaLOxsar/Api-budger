namespace Api_budger.Models.budgers
{
    public class IncomCategory
    {
        public long IncomCategoryId { get; set; }
        public string? IncomCategoryName { get; set; }
        public ICollection<Incom>? Incoms { get; set; }
    }
}
