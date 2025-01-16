using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Api_budger.Services.Abstractions;
using AutoMapper;

namespace Api_budger.Services
{
    public class ClientService : IClientService
    {
        private readonly ILogger<ClientService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IBudgerRepository _budgerRepository;
        private readonly IMapper _mapper;
        public ClientService(ILogger<ClientService> logger, IUserRepository userRepository, IBudgerRepository budgerRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _budgerRepository = budgerRepository;
            _mapper = mapper;
        }
        public Task<Family> AddFamilyAsyns(InputFamily inputFamily)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> AddRoleAsyns(InputRole inputRole)
        {
            var role = _mapper.Map<Role>(inputRole);
            return await _userRepository.AddRoleAsyns(role);
        }

        public Task<User> AddUserAsyns(InputUser inputUser)
        {
            throw new NotImplementedException();
        }

        public Task<Family> CorrectFamilyAsyns(long Id, InputFamily inputFamily)
        {
            throw new NotImplementedException();
        }

        public Task<Role> CorrectRoleAsyns(long Id, InputRole inputRole)
        {
            throw new NotImplementedException();
        }

        public Task<User> CorrectUserAsyns(long Id, InputUser inputUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFamilyByIdAsyns(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleByIdAsyns(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserByIdAsyns(long id)
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

        public Task<Role> GetRoleByIdAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Role>> GetRolesAsync()
        {
            var roles = await _userRepository.GetAllRoleAsync();
            if (roles == null) throw new Exception("Not founs role");
            return roles;
        }

        public Task<User> GetUserByIdAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
