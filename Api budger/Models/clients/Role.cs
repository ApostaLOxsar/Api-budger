namespace Api_budger.Models.clients
{
    public class Role
    {
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleRus { get; set;}
        public ICollection<User>? Users { get; set; }
    }
}
