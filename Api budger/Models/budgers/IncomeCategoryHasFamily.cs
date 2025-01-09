using Api_budger.Models.clients;

namespace Api_budger.Models.budgers
{
    public class IncomeCategoryHasFamily
    {
        public long IncomCategoryHasFamilyId { get; set; }
        public long FamilyId { get; set; }
        public long IncomId { get; set; }
        public Family? Family { get; set; }
        public Incom? Incom { get; set; }
    }
}
