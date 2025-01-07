namespace Api_budger.Models.clients
{
    public class Roles
    {
        public long RoleId { get; set; }
        public string? Role { get; set; }
        public string? RoleRus { get; set;}
        public ICollection<Users>? Users { get; set; }
    }
}
