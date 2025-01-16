using Api_budger.Models.budgers.budgers;
using Api_budger.Models.budgers;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Repositories.ClientRepositoty
{
    /*public class BudgerRepository : IBudgerRepository
    {
        private readonly ApplicationContext _context;

        public BudgerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Budger> AddBudgerAsyns(Budger inputBudger)
        {
            var budger = inputBudger;
            _context.Budgers.Add(budger);
            await _context.SaveChangesAsync();
            return budger;
        }

        public async Task<BudgerCategory> AddBudgerCategoryInFamilyAsyns(BudgerCategory inputBudgerCategory)
        {
            var category = inputBudgerCategory;
            _context.BudgerCategorys.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Incom> AddIncomAsyns(Incom inputIncom)
        {
            var incom = inputIncom;
            _context.Incoms.Add(incom);
            await _context.SaveChangesAsync();
            return incom;
        }

        public async Task<IncomCategory> AddIncomCategoryInFamilyAsyns(IncomCategory inputIncomCategory)
        {
            var category = inputIncomCategory;
            _context.IncomCategorys.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Budger?> CorrectBudgerAsyns(long Id, Budger inputBudger)
        {
            var budger = await _context.Budgers.FindAsync(Id);
            if (budger == null) throw new KeyNotFoundException("Budger not found");

            _context.Entry(budger).CurrentValues.SetValues(inputBudger);
            await _context.SaveChangesAsync();
            return budger;
        }

        public async Task<BudgerCategory?> CorrectBudgerCategoryFromUserByIdAsyns(long id, long userId, BudgerCategory inputBudgerCategory)
        {
            //var category = await _context.BudgerCategorys.FirstOrDefaultAsync(c => c.BudgerCategoryId == id && c.User == userId);
            var category = await _context.BudgerCategorys
                .Join(_context.BudgerCategoryHasFamilies,
                      bc => bc.BudgerCategoryId,
                      bchf => bchf.BudgerCategoryId,
                      (bc, bchf) => new { bc, bchf })
                .Join(_context.Famili,
                      combined => combined.bchf.FamiliId,
                      famili => famili.FamiliId,
                      (combined, famili) => new { combined.bc, famili })
                .Where(x => x.bc.BudgerCategoryId == id && x.famili.UserId == userId)
                .Select(x => x.bc)
                .FirstOrDefaultAsync();


            if (category == null) throw new KeyNotFoundException("BudgerCategory not found");

            _context.Entry(category).CurrentValues.SetValues(inputBudgerCategory);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Incom?> CorrectIncomAsyns(long Id, Incom inputIncom)
        {
            var incom = await _context.Incoms.FindAsync(Id);
            if (incom == null) throw new KeyNotFoundException("Income not found");

            _context.Entry(incom).CurrentValues.SetValues(inputIncom);
            await _context.SaveChangesAsync();
            return incom;
        }

        public async Task<IncomCategory?> CorrectIncomCategoryFromUserByIdAsyns(long Id, long userId, IncomCategory inputIncomCategory)
        {
            var category = await _context.IncomCategorys.FirstOrDefaultAsync(c => c.IncomCategoryId == Id && c.FamilyId == userId);
            if (category == null) throw new KeyNotFoundException("IncomCategory not found");

            _context.Entry(category).CurrentValues.SetValues(inputIncomCategory);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteBudgerByIdAsyns(long budgerId)
        {
            var budger = await _context.Budgers.FindAsync(budgerId);
            if (budger == null) throw new KeyNotFoundException("Budger not found");

            _context.Budgers.Remove(budger);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId, long familyId)
        {
            var category = await _context.BudgerCategorys.FirstOrDefaultAsync(c => c.BudgerCategoryId == budgerCategoryId && c.FamilyId == familyId);
            if (category == null) throw new KeyNotFoundException("Budger category not found");

            _context.BudgerCategorys.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIncomByIdAsyns(long incomId)
        {
            var incom = await _context.Incoms.FindAsync(incomId);
            if (incom == null) throw new KeyNotFoundException("Incom category not found");

            _context.Incoms.Remove(incom);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId, long familyId)
        {
            var category = await _context.IncomCategorys.FirstOrDefaultAsync(c => c.IncomCategoryId == incomCategoryId && c.FamilyId == familyId);
            if (category == null) throw new KeyNotFoundException("Incom category category not found");

            _context.IncomCategorys.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Budger>?> GetBudgerByFamilyIdAsyns(long familyId)
        {
            return await _context.Budgers.Where(b => b.FamilyId == familyId).ToListAsync();
        }

        public async Task<IEnumerable<Budger>?> GetBudgerByUserIdAsyns(long useryId)
        {
            return await _context.Budgers.Where(b => b.UserId == useryId).ToListAsync();
        }

        public async Task<IEnumerable<BudgerCategory>?> GetBudgerCategoryByFamilyIdAsyns(long familyId)
        {
            return await _context.BudgerCategorys.Where(c => c.FamilyId == familyId).ToListAsync();
        }

        public async Task<IEnumerable<Incom>?> GetIncomByFamilyIdAsyns(long familyId)
        {
            return await _context.Incoms.Where(i => i.FamilyId == familyId).ToListAsync();
        }

        public async Task<IEnumerable<Incom>?> GetIncomByUserIdAsyns(long useryId)
        {
            return await _context.Incoms.Where(i => i.UserId == useryId).ToListAsync();
        }

        public async Task<IEnumerable<IncomCategory>?> GetIncomCategoryByFamilyIdAsyns(long familyId)
        {
            return await _context.IncomCategorys.Where(c => c.FamilyId == familyId).ToListAsync();
        }
    }*/
}
