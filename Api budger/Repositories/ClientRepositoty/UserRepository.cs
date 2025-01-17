using System.Text.Json;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Dapper;
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

            var user = await _context.Users.Include(u => u.Role).Include(f => f.Family).FirstOrDefaultAsync();
            if (user is null) throw new Exception("User incorrect save");
            return user;
        }

        public async Task<User?> GetUserByIdAsync(long UserId)
        {
            return await _context.Users.FindAsync(UserId);
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
    }
}
