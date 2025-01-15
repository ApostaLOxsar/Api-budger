using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class IncomCategoryHasFamily
    {
        public long IncomCategoryHasFamilyId { get; set; }
        public long FamilyId { get; set; }
        public long IncomCategoryId { get; set; }
        public Family? Family { get; set; }
        public IncomCategory? IncomCategory { get; set; }
    }
}
