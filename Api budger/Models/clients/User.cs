using Api_budger.Models.budgers;
using Api_budger.Models.Abstractions;

namespace Api_budger.Models.clients
{
    public class User : UserBase
    {
        public long UserId { get; set; }
        public Role? Role { get; set; }
        public Family? Family { get; set; }
        public ICollection<Incom>? Incoms { get; set; }
        public ICollection<Budger>? Buders { get; set; }
    }
}
