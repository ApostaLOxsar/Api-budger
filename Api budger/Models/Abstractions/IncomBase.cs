namespace Api_budger.Models.Abstractions
{
    public class IncomBase
    {
        /// <summary>
        /// Название доходов
        /// </summary>
        public string? IncomName { get; set; }
        /// <summary>
        /// Комментарий к доходу
        /// </summary>
        public string? Comment { get; set; }
    }
}
