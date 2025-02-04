using Api_budger.Models.clients;
using Api_budger.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Api_budger.Repositories.ClientRepositoty
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<User>?> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Role).Include(u => u.Family).ToListAsync();
        }

        public async Task<User> AddUserAsyns(User inputUser)
        {
            var result = await _context.Users.AddAsync(inputUser);
            await _context.SaveChangesAsync();

            var user = await _context.Users.Include(u => u.Role).Include(f => f.Family).FirstOrDefaultAsync(u => u.UserId == result.Entity.UserId);
            if (user is null) throw new Exception("User incorrect save");
            return user;
        }

        public async Task<User?> GetUserByIdAsync(long UserId)
        {
            return await _context.Users.Include(u => u.Role).Include(u => u.Family)
                .FirstOrDefaultAsync(u => u.UserId == UserId);
        }

        public async Task<bool> DeleteUserByIdAsync(long UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>?> GetAllRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(long RoleId)
        {
            return await _context.Roles.FindAsync(RoleId);
        }

        public async Task<Role> AddRoleAsyns(Role inputRole)
        {
            var result = await _context.Roles.AddAsync(inputRole);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteRoleByIdAsyns(long RoleId)
        {
            var role = await _context.Roles.FindAsync(RoleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Family>?> GetAllFamilyAsync()
        {
            return await _context.Families.ToListAsync();
        }

        public async Task<Family?> GetFamilyByIdAsync(long familyId)
        {
            return await _context.Families.FindAsync(familyId);
        }

        public async Task<Family?> GetFamilyByUserIdAsync(long userId)
        {
            var famili = await _context.Families
                 .Join(_context.Users,
                       f => f.FamilyId,
                       u => u.FamilyId,
                       (f, u) => new { f, u })
                 .Where(x => x.u.UserId == userId)
                 .Select(x => x.f)
                 .FirstOrDefaultAsync();
            return famili;
        }

        public async Task<Family> AddFamilyAsyns(Family inputFamily)
        {
            var result = await _context.Families.AddAsync(inputFamily);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteFamilyByIdAsyns(long familyId)
        {
            var family = await _context.Families.FindAsync(familyId);
            if (family == null)
                throw new KeyNotFoundException("Family not found");

            _context.Families.Remove(family);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> CorrectUserByIdAsyns(long UserId, User inputUser)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            inputUser.UserId = user.UserId;
            _context.Entry(user).CurrentValues.SetValues(inputUser);

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Role> CorrectRoleByIdAsyns(long RoleId, Role inputRole)
        {
            var role = await _context.Roles.FindAsync(RoleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found");

            inputRole.RoleId = role.RoleId;
            _context.Entry(role).CurrentValues.SetValues(inputRole);

            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Family> CorrectFamilyByIdAsyns(long FamilyId, Family inputFamily)
        {
            var family = await _context.Families.FindAsync(FamilyId);
            if (family == null)
                throw new KeyNotFoundException("Family not found");

            inputFamily.FamilyId = FamilyId;
            _context.Entry(family).CurrentValues.SetValues(inputFamily);

            await _context.SaveChangesAsync();
            return family;
        }

        public async Task<string> GetHashByUserIdAsync(long userId)
        {
            var userPassHash = await _context.Users.Where(user => user.UserId == userId).Select(u => u.PasswordHash).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Pass not found");
            return userPassHash;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<User> GetUserByTelegramIdAsync(long telegramId)
        {
            var user = await _context.Users.Where(u => u.TelegramId == telegramId).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<long> GetUserIdByFamilyAsync(long familyId)
        {
            var userId = await _context.Users.Where(u => u.FamilyId == familyId)
                .Select(u => u.UserId)
                .FirstOrDefaultAsync();
            return userId;
        }

        public async Task<long> GetFamilyIdByUserIdAsync(long userId)
        {
            var familyId = await _context.Users.Where(u => u.UserId == userId)
                .Select(u => u.FamilyId)
                .FirstOrDefaultAsync();
            return userId;
        }
    }
}
