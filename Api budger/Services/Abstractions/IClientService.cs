using Api_budger.Models.clients;
using Api_budger.Models.input;

namespace Api_budger.Services.Abstractions
{
    public interface IClientService
    {
        #region Family
        public Task<IEnumerable<Family>> GetFamiliesAsync();
        public Task<Family> GetFamilyByIdAsync(long Id);
        public Task<Family> GetFamilyByUserIdAsync(long Id);
        public Task<Family> AddFamilyAsyns(InputFamily inputFamily);
        public Task<bool> DeleteFamilyByIdAsyns(long id);
        public Task<Family> CorrectFamilyAsyns(long Id, InputFamily inputFamily);
        #endregion

        #region Role
        public Task<IEnumerable<Role>> GetRolesAsync();
        public Task<Role> GetRoleByIdAsync(long Id);
        public Task<Role> AddRoleAsyns(InputRole inputRole);
        public Task<bool> DeleteRoleByIdAsyns(long id);
        public Task<Role> CorrectRoleAsyns(long Id, InputRole inputRole);
        #endregion

        #region User
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(long Id);
        public Task<User> AddUserAsyns(InputUser inputUser);
        public Task<bool> DeleteUserByIdAsyns(long id);
        public Task<User> CorrectUserAsyns(long Id, InputUser inputUser);
        #endregion

        #region Verify
        public Task<string> GenerateHash(string password);
        public Task Login(LoginInput loginInput);
        public Task Logout();
        #endregion
    }
}
