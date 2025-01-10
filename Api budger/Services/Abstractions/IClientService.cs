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
        Task<Family> CorrectFamily(long Id, InputFamily inputFamily);
        #endregion

        #region Role

        #endregion


        #region User

        #endregion
    }
}
