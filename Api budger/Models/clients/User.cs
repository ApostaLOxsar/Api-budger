using Api_budger.Models.budgers;
using Api_budger.Models.Abstractions;
using System.Text.Json.Serialization;

namespace Api_budger.Models.clients
{
    public class User : UserBase
    {
        public long UserId { get; set; }
        public Role? Role { get; set; }
        public Family? Family { get; set; }
        [JsonIgnore]
        public IEnumerable<Incom>? Incoms { get; set; }
        [JsonIgnore]
        public IEnumerable<Budger>? Buders { get; set; }
    }
}
