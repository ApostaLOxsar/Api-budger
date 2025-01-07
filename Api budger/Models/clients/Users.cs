using Api_budger.Models.budgers;

namespace Api_budger.Models.clients
{
    public class Users
    {
        public long UserId { get; set; }
        public long TelegramId { get; set; }
        public long RoleId { get; set; }
        public long FamilyId { get; set; }
    }
}
