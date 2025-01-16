using System.Text.Json.Serialization;
using Api_budger.Models.Abstractions;

namespace Api_budger.Models.clients
{
    public class Role : RoleBase
    {
        public long RoleId { get; set; }
        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}
