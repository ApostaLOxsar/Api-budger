using Api_budger.Models.clients;
using Api_budger.Models.input;

namespace Api_budger.Services.Abstractions
{
    public interface IClientService
    {
        #region Family
        Task<ICollection<Family>> GetFamiliesAsync();
        Task<Family> GetFamilyByIdAsync(long Id);
        Task<Family> AddFamilyAsyns(InputFamily inputFamily);
        Task<bool> DeleteFamilyByIdAsyns(long id);
        Task<Family> CorrectFamilyAsyns(long Id, InputFamily inputFamily);
        #endregion

        #region Role
        Task<ICollection<Role>> GetRolesAsync();
        Task<Role> GetRoleByIdAsync(long Id);
        Task<Role> AddRoleAsyns(InputRole inputRole);
        Task<bool> DeleteRoleByIdAsyns(long id);
        Task<Role> CorrectRoleAsyns(long Id, InputRole inputRole);
        #endregion


        #region User
        Task<ICollection<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(long Id);
        Task<User> AddUserAsyns(InputUser inputUser);
        Task<bool> DeleteUserByIdAsyns(long id);
        Task<User> CorrectUserAsyns(long Id, InputUser inputUser);
        #endregion
    }
}
