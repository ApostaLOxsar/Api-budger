namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategories
    {
        public long BudgerCategorieId { get; set; }
        public string? BudgerCategoriy { get; set; }
        public ICollection<Budgers>? Budgers { get; set; }
    }
}
