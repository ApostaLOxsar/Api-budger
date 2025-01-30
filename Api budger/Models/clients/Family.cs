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
        public IEnumerable<User>? Users { get; set; }
        [JsonIgnore]
        public IEnumerable<IncomCategory>? IncomeCategories { get; set; }
        [JsonIgnore]
        public IEnumerable<BudgerCategory>? BudgerCategories { get; set; }
    }
}
