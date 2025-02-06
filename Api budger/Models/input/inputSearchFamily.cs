namespace Api_budger.Models.input
{
    public class inputSearchFamily
    {
        /// <summary>
        /// Ид пользователя в телеграмме
        /// </summary>
        public long? TelegramId { get; set; }
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
    }
}
