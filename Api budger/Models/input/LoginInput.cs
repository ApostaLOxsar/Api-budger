using System.ComponentModel.DataAnnotations;

namespace Api_budger.Models.input
{
    public class LoginInput
    {
        public string? email { get; set; }
        public long? telegramId { get; set; }
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
