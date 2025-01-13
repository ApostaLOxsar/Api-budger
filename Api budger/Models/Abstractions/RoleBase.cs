namespace Api_budger.Models.Abstractions
{
    public class RoleBase
    {
        /// <summary>
        /// Название роли пользователя
        /// </summary>
        public string? RoleName { get; set; }
        /// <summary>
        /// Название роли пользователя на русском
        /// </summary>
        public string? RoleRus { get; set; }
    }
}
