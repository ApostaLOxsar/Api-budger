namespace Api_budger.Models.budgers.budgers
{
    public class BudgerCategory
    {
        public long BudgerCategorieId { get; set; }
        public string? BudgerCategoryName { get; set; }
        public ICollection<Budger>? Budgers { get; set; }
    }
}
