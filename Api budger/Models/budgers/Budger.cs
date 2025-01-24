using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;
using Api_budger.Models.Abstractions;

namespace Api_budger.Models.budgers
{
    public class Budger : BudgerBase
    {
        public long BudgerId { get; set; }
        public DateTime Date { get; set; }
        public User? User { get; set; }
        public BudgerCategory? BudgerCategory { get; set; }
    }
}
