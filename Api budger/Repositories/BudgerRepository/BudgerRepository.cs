using Api_budger.Models.budgers.budgers;
using Api_budger.Models.budgers;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Api_budger.Models.clients;

namespace Api_budger.Repositories.BudgerRepository
{
    public class BudgerRepository : IBudgerRepository
    {
        private readonly ApplicationContext _context;

        public BudgerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budger>> AddBudgersAsyns(IEnumerable<Budger> inputBudger)
        {
            var budger = inputBudger;
            _context.Budgers.AddRange(budger);
            await _context.SaveChangesAsync();
            return budger;
        }

        public async Task<IEnumerable<BudgerCategory>> AddBudgerCategoryInFamilyAsyns(long familiId, IEnumerable<BudgerCategory> inputBudgerCategory)
        {
            var category = inputBudgerCategory;
            await _context.BudgerCategories.AddRangeAsync(category);

            List<BudgerCategoryHasFamily> budgersCategoryHasFamily = new List<BudgerCategoryHasFamily>();
            foreach (var budgerCategory in inputBudgerCategory)
            {
                budgersCategoryHasFamily.Add(new BudgerCategoryHasFamily
                {
                    FamilyId = familiId,
                    BudgerCategory = budgerCategory
                });
            }
            await _context.AddRangeAsync(budgersCategoryHasFamily);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Incom>> AddIncomsAsyns(IEnumerable<Incom> inputIncom)
        {
            var incom = inputIncom;
            _context.Incoms.AddRange(incom);
            await _context.SaveChangesAsync();
            return incom;
        }

        public async Task<IEnumerable<IncomCategory>> AddIncomCategoryInFamilyAsyns(long familiId, IEnumerable<IncomCategory> inputIncomCategory)
        {
            var category = inputIncomCategory;
            await _context.IncomCategories.AddRangeAsync(category);

            List<IncomCategoryHasFamily> incomsCategoryHasFamily = new List<IncomCategoryHasFamily>();
            foreach (var incomCategory in inputIncomCategory)
            {
                incomsCategoryHasFamily.Add(new IncomCategoryHasFamily
                {
                    FamilyId = familiId,
                    IncomCategory = incomCategory
                });
            }
            await _context.AddRangeAsync(incomsCategoryHasFamily);
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
            var category = await _context.BudgerCategories
                 .Join(_context.BudgerCategoryHasFamilies,
                       bc => bc.BudgerCategoryId,
                       bchf => bchf.BudgerCategoryId,
                       (bc, bchf) => new { bc, bchf })
                 .Join(_context.Families,
                       combined => combined.bchf.FamilyId,
                       famili => famili.FamilyId,
                       (combined, famili) => new { combined.bc, famili })
                 .Join(_context.Users,
                       combined => combined.famili.FamilyId,
                       user => user.FamilyId,
                       (combined, user) => new { combined.bc, user })
                 .Where(x => x.bc.BudgerCategoryId == id && x.user.UserId == userId)
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

        public async Task<IncomCategory?> CorrectIncomCategoryFromUserByIdAsyns(long id, long userId, IncomCategory inputIncomCategory)
        {
            var category = await _context.IncomCategories
                .Join(_context.IncomCategoriesHasFamilies,
                    bc => bc.IncomCategoryId,
                    bchf => bchf.IncomCategoryId,
                    (bc, bchf) => new { bc, bchf })
                .Join(_context.Families,
                    combined => combined.bchf.FamilyId,
                    famili => famili.FamilyId,
                    (combined, famili) => new { combined.bc, famili })
                .Join(_context.Users,
                    combined => combined.famili.FamilyId,
                    user => user.FamilyId,
                    (combined, user) => new { combined.bc, user })
                .Where(x => x.bc.IncomCategoryId == id && x.user.UserId == userId)
                .Select(x => x.bc)
                .FirstOrDefaultAsync();

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
            var category = await _context.BudgerCategories
                 .Join(_context.BudgerCategoryHasFamilies,
                       bc => bc.BudgerCategoryId,
                       bchf => bchf.BudgerCategoryId,
                       (bc, bchf) => new { bc, bchf })
                 .Join(_context.Families,
                       combined => combined.bchf.FamilyId,
                       famili => famili.FamilyId,
                       (combined, famili) => new { combined.bc, famili })
                 .Where(x => x.bc.BudgerCategoryId == budgerCategoryId && x.famili.FamilyId == familyId)
                 .Select(x => x.bc)
                 .FirstOrDefaultAsync();

            if (category == null) throw new KeyNotFoundException("Budger category not found");

            _context.BudgerCategories.Remove(category);
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
            var category = await _context.IncomCategories
                 .Join(_context.IncomCategoriesHasFamilies,
                       bc => bc.IncomCategoryId,
                       bchf => bchf.IncomCategoryId,
                       (bc, bchf) => new { bc, bchf })
                 .Join(_context.Families,
                       combined => combined.bchf.FamilyId,
                       famili => famili.FamilyId,
                       (combined, famili) => new { combined.bc, famili })
                 .Where(x => x.bc.IncomCategoryId == incomCategoryId && x.famili.FamilyId == familyId)
                 .Select(x => x.bc)
                 .FirstOrDefaultAsync();
            if (category == null) throw new KeyNotFoundException("Incom category category not found");

            _context.IncomCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Budger>?> GetBudgerByFamilyIdAsyns(long familyId)
        {
            var budgers = await _context.Budgers
                 .Where(b => _context.Users.Any(u => u.UserId == b.UserId && u.FamilyId == familyId))
                 .ToListAsync();
            return budgers;
        }

        public async Task<IEnumerable<Budger>?> GetBudgerByUserIdAsyns(long useryId)
        {
            return await _context.Budgers.Where(b => b.UserId == useryId).ToListAsync();
        }

        public async Task<IEnumerable<BudgerCategory>?> GetBudgerCategoryByFamilyIdAsyns(long familyId)
        {
            var category = await _context.BudgerCategories
                .Join(_context.BudgerCategoryHasFamilies,
                    bc => bc.BudgerCategoryId,
                    bchf => bchf.BudgerCategoryId,
                    (bc, bchf) => new { bc, bchf })
                .Join(_context.Families,
                    combined => combined.bchf.FamilyId,
                    famili => famili.FamilyId,
                    (combined, famili) => new { combined.bc, famili })
                .Where(x => x.famili.FamilyId == familyId)
                .Select(x => x.bc)
                .ToListAsync();

            return category;
        }

        public async Task<IEnumerable<Incom>?> GetIncomByFamilyIdAsyns(long familyId)
        {
            var incoms = await _context.Incoms
                 .Where(b => _context.Users.Any(u => u.UserId == b.UserId && u.FamilyId == familyId))
                 .ToListAsync();
            return incoms;
        }

        public async Task<IEnumerable<Incom>?> GetIncomByUserIdAsyns(long useryId)
        {
            return await _context.Incoms.Where(i => i.UserId == useryId).ToListAsync();
        }

        public async Task<IEnumerable<IncomCategory>?> GetIncomCategoryByFamilyIdAsyns(long familyId)
        {
            var category = await _context.IncomCategories
                .Join(_context.IncomCategoriesHasFamilies,
                    bc => bc.IncomCategoryId,
                    bchf => bchf.IncomCategoryId,
                    (bc, bchf) => new { bc, bchf })
                .Join(_context.Families,
                    combined => combined.bchf.FamilyId,
                    famili => famili.FamilyId,
                    (combined, famili) => new { combined.bc, famili })
                .Where(x => x.famili.FamilyId == familyId)
                .Select(x => x.bc)
                .ToListAsync();

            return category;
        }

        public async Task<IEnumerable<DefaultIncomeCategory>> GetDefaultIncomCategoryAsyns()
        {
            var defaultCategory = await _context.DefaultIncomeCategories.ToListAsync();
            if (defaultCategory.Count <= 0) throw new Exception("No default category");
            return defaultCategory;
        }

        public async Task<IEnumerable<DefaultBudgerCategory>> GetDefaultBudgerCategoryAsyns()
        {
            var defaultCategory = await _context.DefaultBudgerCategories.ToListAsync();
            if (defaultCategory.Count <= 0) throw new Exception("No default category");
            return defaultCategory;
        }

        public async Task AddDefaultIncomCategoryAsyns(IEnumerable<DefaultIncomeCategory> incomCategories)
        {
            await _context.DefaultIncomeCategories.AddRangeAsync(incomCategories);
            await _context.SaveChangesAsync();
        }

        public async Task AddDefaultBudgerCategoryAsyns(IEnumerable<DefaultBudgerCategory> budgerCategories)
        {
            await _context.DefaultBudgerCategories.AddRangeAsync(budgerCategories);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDefaultIncomCategoryAsyns(long defaultIncomCategoryId)
        {
            var defaultIncomCategory = await _context.DefaultIncomeCategories.FindAsync(defaultIncomCategoryId);
            if (defaultIncomCategory == null) throw new KeyNotFoundException("default incom category not found");

            _context.DefaultIncomeCategories.Remove(defaultIncomCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDefaultBudgerCategoryAsyns(long defaultBudgerCategoryId)
        {
            var defaultBudgerCategories = await _context.DefaultBudgerCategories.FindAsync(defaultBudgerCategoryId);
            if (defaultBudgerCategories == null) throw new KeyNotFoundException("default budger category not found");

            _context.DefaultBudgerCategories.Remove(defaultBudgerCategories);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<long>> GetUserIdByBudgerCategoryId(long budgerCategoryId)
        {
            var category = await _context.BudgerCategories
                .Where(c => c.BudgerCategoryId == budgerCategoryId)
                .Join(_context.BudgerCategoryHasFamilies,
                      bc => bc.BudgerCategoryId,
                      bchf => bchf.BudgerCategoryId,
                      (bc, bchf) => new { bc, bchf })
                .Join(_context.Families,
                      bchfbc => bchfbc.bchf.FamilyId,
                      f => f.FamilyId,
                      (bchfbc, f) => new { bchfbc, f })
                .Join(_context.Users,
                      bchfbcf => bchfbcf.f.FamilyId,
                      u => u.FamilyId,
                      (bchfbc, u) => new { bchfbc , u})
                .Select(u => u.u.UserId)
                .ToListAsync();
            return category;
        }

        public async Task<IEnumerable<long>> GetUserIdsByBydgerIdAsyns(long budgerId)
        {
            var userId = await _context.Budgers
                .Where(b => b.BudgerId == budgerId)
                .Join(_context.Users,
                b => b.UserId,
                u => u.UserId,
                (b, u) => new { b, u })
                .Join(_context.Families,
                bu => bu.u.FamilyId,
                f => f.FamilyId,
                (bu, f) => new { bu, f })
                .Select(buf => buf.bu.u.UserId)
                .ToListAsync();

            return userId;
        }

        public async Task<IEnumerable<long>> GetUserIdByIncomCategoryId(long incomCategoryId)
        {
            var category = await _context.IncomCategories
                .Where(c => c.IncomCategoryId == incomCategoryId)
                .Join(_context.IncomCategoriesHasFamilies,
                      bc => bc.IncomCategoryId,
                      bchf => bchf.IncomCategoryId,
                      (bc, bchf) => new { bc, bchf })
                .Join(_context.Families,
                      bchfbc => bchfbc.bchf.FamilyId,
                      f => f.FamilyId,
                      (bchfbc, f) => new { bchfbc, f })
                .Join(_context.Users,
                      bchfbcf => bchfbcf.f.FamilyId,
                      u => u.FamilyId,
                      (bchfbc, u) => new { bchfbc, u })
                .Select(u => u.u.UserId)
                .ToListAsync();
            return category;
        }

        public async Task<IEnumerable<long>> GetUserIdsByIncomIdAsyns(long incomId)
        {
            var userId = await _context.Incoms
                .Where(b => b.IncomId == incomId)
                .Join(_context.Users,
                b => b.UserId,
                u => u.UserId,
                (b, u) => new { b, u })
                .Join(_context.Families,
                bu => bu.u.FamilyId,
                f => f.FamilyId,
                (bu, f) => new { bu, f })
                .Select(buf => buf.bu.u.UserId)
                .ToListAsync();

            return userId;
        }
    }
}
