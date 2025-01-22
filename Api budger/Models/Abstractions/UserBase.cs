namespace Api_budger.Models.Abstractions
{
    public class UserBase
    {
        /// <summary>
        /// Ид пользователя в телеграмме
        /// </summary>
        public long TelegramId { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string? Soname { get; set; }
        /// <summary>
        /// Ид семьи пользователя
        /// </summary>
        public long FamilyId { get; set; }
        /// <summary>
        /// Ид роли пользователя
        /// </summary>
        public long RoleId { get; set; }
    }
}
