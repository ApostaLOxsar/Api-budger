using Api_budger.Models.Abstractions;

namespace Api_budger.Models.input
{
    public class InputUser : UserBase
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string password { get; set; } = string.Empty;
    }
}
