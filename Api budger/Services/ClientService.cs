using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Api_budger.Services.Abstractions;

namespace Api_budger.Services
{
    public class ClientService : IClientService
    {
        private readonly IUserRepository _userRepository;
        public ClientService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public Task<Family> AddFamilyAsyns(InputFamily inputFamily)
        {
            throw new NotImplementedException();
        }

        public Task<Family> CorrectFamily(long Id, InputFamily inputFamily)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFamilyByIdAsyns(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Family>> GetFamiliesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Family> GetFamilyByIdAsync(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
