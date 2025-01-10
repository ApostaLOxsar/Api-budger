using Api_budger.Models.clients;
using Api_budger.Repositories.Abstractions;

namespace Api_budger.Repositories.ClientRepositoty
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _contex;

        public UserRepository(ApplicationContext contex)
        {
            _contex = contex;
        }

        public Task<Family> AddFamilyAsyns(Family inputFamily)
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddRoleAsyns(Role inputRole)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUserAsyns(User inputUser)
        {
            throw new NotImplementedException();
        }

        public Task<Family> CorrectFamilyByIdAsyns(long FamilyId, User inputFamily)
        {
            throw new NotImplementedException();
        }

        public Task<Role> CorrectRoleByIdAsyns(long RoleId, User inputRole)
        {
            throw new NotImplementedException();
        }

        public Task<User> CorrectUserByIdAsyns(long UserId, User inputUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFamilyByIdAsyns(long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleByIdAsyns(long RoleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserByIdAsync(long UserId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Family>?> GetAllFamilyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Role>?> GetAllRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>?> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Family?> GetFamilyByIdAsync(long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<Role?> GetRoleByIdAsync(long RoleId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdAsync(long UserId)
        {
            throw new NotImplementedException();
        }
    }
}
