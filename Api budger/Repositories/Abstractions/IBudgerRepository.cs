using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.input;

namespace Api_budger.Repositories.Abstractions
{
    public interface IBudgerRepository
    {
        public Task<IEnumerable<Budger>> AddBudgersAsyns(IEnumerable<Budger> inputBudger);
        public Task<IEnumerable<BudgerCategory>> AddBudgerCategoryInFamilyAsyns(IEnumerable<BudgerCategory> inputBudger);
        public Task<IEnumerable<Incom>> AddIncomsAsyns(IEnumerable<Incom> inputIncom);
        public Task<IEnumerable<IncomCategory>> AddIncomCategoryInFamilyAsyns(IEnumerable<IncomCategory> inputIncomCategory);
        public Task<Budger?> CorrectBudgerAsyns(long Id, Budger inputBudger);
        public Task<BudgerCategory?> CorrectBudgerCategoryFromUserByIdAsyns(long id, long userId, BudgerCategory inputBudgerCategory);
        public Task<Incom?> CorrectIncomAsyns(long Id, Incom inputIncom);
        public Task<IncomCategory?> CorrectIncomCategoryFromUserByIdAsyns(long Id, long userId, IncomCategory inputIncomCategory);
        public Task<bool> DeleteBudgerByIdAsyns(long budgerId);
        public Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId, long familyId);
        public Task<bool> DeleteIncomByIdAsyns(long incomId);
        public Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId, long familyId);
        public Task<IEnumerable<Budger>?> GetBudgerByFamilyIdAsyns(long familyId);
        public Task<IEnumerable<Budger>?> GetBudgerByUserIdAsyns(long useryId);
        public Task<IEnumerable<BudgerCategory>?> GetBudgerCategoryByFamilyIdAsyns(long familyId);
        public Task<IEnumerable<Incom>?> GetIncomByFamilyIdAsyns(long familyId);
        public Task<IEnumerable<Incom>?> GetIncomByUserIdAsyns(long useryId);
        public Task<IEnumerable<IncomCategory>?> GetIncomCategoryByFamilyIdAsyns(long familyId);
        public Task<IEnumerable<DefaultIncomeCategory>> GetDefaultIncomCategoryAsyns();
        public Task<IEnumerable<DefaultBudgerCategory>> GetDefaultBudgerCategoryAsyns();
        public Task AddDefaultIncomCategoryAsyns(IEnumerable<DefaultIncomeCategory> incomCategory);
        public Task AddDefaultBudgerCategoryAsyns(IEnumerable<DefaultBudgerCategory> budgerCategory);
        public Task<bool> DeleteDefaultIncomCategoryAsyns(long id);
        public Task<bool> DeleteDefaultBudgerCategoryAsyns(long id);
    }
}
