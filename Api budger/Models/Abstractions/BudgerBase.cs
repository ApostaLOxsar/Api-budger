namespace Api_budger.Models.Abstractions
{
    public class BudgerBase
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public long UserId { get; set; }
         /// <summary>
        /// Сумма
        /// </summary>
        public double BudgerAmount { get; set;}
        /// <summary>
        /// Название расхода
        /// </summary>
        public string? BudgerName { get; set; }
        /// <summary>
        /// Коментарий
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// Id категории расходов
        /// </summary>
        public long BudgerCategoriyId { get; set; }
    }
}
