using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.input;

namespace Api_budger.Repositories.Abstractions
{
    public interface IBudgerRepository
    {
        public Task<Budger> AddBudgerAsyns(Budger inputBudger);
        public Task<BudgerCategory> AddBudgerCategoryInFamilyAsyns(BudgerCategory inputBudger);
        public Task<Incom> AddIncomAsyns(Incom inputIncom);
        public Task<IncomCategory> AddIncomCategoryInFamilyAsyns(IncomCategory inputIncomCategory);
        public Task<Budger?> CorrectBudgerAsyns(long Id, Budger inputBudger);
        public Task<BudgerCategory?> CorrectBudgerCategoryFromUserByIdAsyns(long id, long userId, BudgerCategory inputBudgerCategory);
        public Task<Incom?> CorrectIncomAsyns(long Id, Incom inputIncom);
        public Task<IncomCategory?> CorrectIncomCategoryFromUserByIdAsyns(long Id, long userId, IncomCategory inputIncomCategory);
        public Task<bool> DeleteBudgerByIdAsyns(long budgerId);
        public Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId, long familyId);
        public Task<bool> DeleteIncomByIdAsyns(long incomId);
        public Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId, long familyId);
        public Task<List<Budger>?> GetBudgerByFamilyIdAsyns(long familyId);
        public Task<List<Budger>?> GetBudgerByUserIdAsyns(long useryId);
        public Task<List<BudgerCategory>?> GetBudgerCategoryByFamilyIdAsyns(long familyId);
        public Task<List<Incom>?> GetIncomByFamilyIdAsyns(long familyId);
        public Task<List<Incom>?> GetIncomByUserIdAsyns(long useryId);
        public Task<List<IncomCategory>?> GetIncomCategoryByFamilyIdAsyns(long familyId);
    }
}
