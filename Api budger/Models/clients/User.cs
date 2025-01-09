using Api_budger.Models.budgers;

namespace Api_budger.Models.clients
{
    public class User
    {
        public long UserId { get; set; }
        public long TelegramId { get; set; }
        public long RoleId { get; set; }
        public long FamilyId { get; set; }
        public Role? Role { get; set; }
        public Family? Family { get; set; }
        public ICollection<Incom>? Incoms { get; set; }
        public ICollection<Budger>? Buders { get; set; }
    }
}
