using Api_budger.Models.Abstractions;

namespace Api_budger.Models.clients
{
    public class Role : RoleBase
    {
        public long RoleId { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
