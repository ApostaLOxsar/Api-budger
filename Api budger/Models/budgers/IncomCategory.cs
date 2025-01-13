using Api_budger.Models.Abstractions;

namespace Api_budger.Models.budgers
{
    public class IncomCategory : IncomCategoryBase
    {
        public long IncomCategoryId { get; set; }
        public ICollection<Incom>? Incoms { get; set; }
    }
}
