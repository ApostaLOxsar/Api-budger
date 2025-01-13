namespace Api_budger.Models.Abstractions
{
    public class BudgerBase
    {
        /// <summary>
        /// Название расхода
        /// </summary>
        public string? BudgerName { get; set; }
        /// <summary>
        /// Коментарий
        /// </summary>
        public string? Comment { get; set; }
    }
}
