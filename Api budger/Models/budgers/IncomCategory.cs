using Api_budger.Models.Abstractions;
using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class IncomCategory : IncomCategoryBase
    {
        public long IncomCategoryId { get; set; }
        public IEnumerable<Family>? Families { get; set; }
        public IEnumerable<Incom>? Incoms { get; set; }
    }
}
