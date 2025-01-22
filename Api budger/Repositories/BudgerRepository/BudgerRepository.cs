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

        public async Task<ICollection<Budger>> AddBudgersAsyns(ICollection<Budger> inputBudger)
        {
            var budger = inputBudger;
            _context.Budgers.AddRange(budger);
            await _context.SaveChangesAsync();
            return budger;
        }

        public async Task<ICollection<BudgerCategory>> AddBudgerCategoryInFamilyAsyns(ICollection<BudgerCategory> inputBudgerCategory)
        {
            var category = inputBudgerCategory;
            _context.BudgerCategories.AddRange(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<ICollection<Incom>> AddIncomsAsyns(ICollection<Incom> inputIncom)
        {
            var incom = inputIncom;
            _context.Incoms.AddRange(incom);
            await _context.SaveChangesAsync();
            return incom;
        }

        public async Task<ICollection<IncomCategory>> AddIncomCategoryInFamilyAsyns(ICollection<IncomCategory> inputIncomCategory)
        {
            var category = inputIncomCategory;
            _context.IncomCategories.AddRange(category);
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

        public async Task<List<Budger>?> GetBudgerByFamilyIdAsyns(long familyId)
        {
            var budgers = await _context.Budgers
                 .Where(b => _context.Users.Any(u => u.UserId == b.UserId && u.FamilyId == familyId))
                 .ToListAsync();
            return budgers;
        }

        public async Task<List<Budger>?> GetBudgerByUserIdAsyns(long useryId)
        {
            return await _context.Budgers.Where(b => b.UserId == useryId).ToListAsync();
        }

        public async Task<List<BudgerCategory>?> GetBudgerCategoryByFamilyIdAsyns(long familyId)
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

        public async Task<List<Incom>?> GetIncomByFamilyIdAsyns(long familyId)
        {
            var incoms = await _context.Incoms
                 .Where(b => _context.Users.Any(u => u.UserId == b.UserId && u.FamilyId == familyId))
                 .ToListAsync();
            return incoms;
        }

        public async Task<List<Incom>?> GetIncomByUserIdAsyns(long useryId)
        {
            return await _context.Incoms.Where(i => i.UserId == useryId).ToListAsync();
        }

        public async Task<List<IncomCategory>?> GetIncomCategoryByFamilyIdAsyns(long familyId)
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
    }
}
