using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.Abstractions;
using System.Text.Json.Serialization;

namespace Api_budger.Models.clients
{
    public class Family : FamilyBase
    {
        public long FamilyId { get; set; }
        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
        [JsonIgnore]
        public ICollection<IncomCategoryHasFamily>? IncomeCategoryHasFamilies { get; set; }
        [JsonIgnore]
        public ICollection<BudgerCategoryHasFamily>? BudgerCategoryHasFamilies { get; set; }
    }
}
