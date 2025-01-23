using System.Text.Json.Serialization;
using Api_budger.Models.Abstractions;

namespace Api_budger.Models.clients
{
    public class Role : RoleBase
    {
        public long RoleId { get; set; }
        [JsonIgnore]
        public IEnumerable<User>? Users { get; set; }
    }
}
