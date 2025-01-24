namespace Api_budger.Models.Abstractions
{
    public class IncomBase
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public double IncomeAmount { get; set; }
        /// <summary>
        /// Название доходов
        /// </summary>
        public string? IncomName { get; set; }
        /// <summary>
        /// Комментарий к доходу
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// Id категории доходов
        /// </summary>
        public long IncomeCategoryId { get; set; }
    }
}
