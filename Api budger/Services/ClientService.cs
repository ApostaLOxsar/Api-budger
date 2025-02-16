using System.Net;
using Api_budger.Consts;
using Api_budger.Infrastructure;
using Api_budger.Infrastructure.Interface;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
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
        private readonly IPasswordHashService _passwordHashService;
        private readonly IJwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _context;
        private readonly ICurentUserService _currentUserService;
        public ClientService(ILogger<ClientService> logger,
                             IUserRepository userRepository,
                             IBudgerRepository budgerRepository,
                             IMapper mapper,
                             IPasswordHashService passwordHashService,
                             IJwtProvider jwtProvider,
                             IHttpContextAccessor httpContext,
                             ICurentUserService currentUserService)
        {
            _jwtProvider = jwtProvider;
            _logger = logger;
            _userRepository = userRepository;
            _budgerRepository = budgerRepository;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
            _context = httpContext;
            _currentUserService = currentUserService;
        }

        #region public region
        public async Task<Family> AddFamilyAsyns(InputFamily inputFamily)
        {
            var famili = _mapper.Map<Family>(inputFamily);
            return await _userRepository.AddFamilyAsyns(famili);
        }

        public async Task<Role> AddRoleAsyns(InputRole inputRole)
        {
            var role = _mapper.Map<Role>(inputRole);
            return await _userRepository.AddRoleAsyns(role);
        }

        public async Task<User> AddUserAsyns(InputUser inputUser)
        {
            var user = _mapper.Map<User>(inputUser);

            string familiName = user.Name + (string.IsNullOrEmpty(user.Soname) ? (" " + user.Soname) : "") + " famili";

            if (user.FamilyId <= 0)
            {
                var famili = await _userRepository.AddFamilyAsyns(new Family { Name = familiName });
                user.FamilyId = famili.FamilyId;
            }

            if (user.RoleId <= 0)
            {
                user.RoleId = 3;
            }

            await AddDefaultCategoryInFamily(user.FamilyId);
            user.PasswordHash = _passwordHashService.GenerateHash(inputUser.password);

            return await _userRepository.AddUserAsyns(user);
        }

        public async Task<Family> CorrectFamilyAsyns(InputFamily inputFamily)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var famili = _mapper.Map<Family>(inputFamily);
            return await _userRepository.CorrectFamilyByIdAsyns(familyId, famili);
        }

        public async Task<Role> CorrectRoleAsyns(long id, InputRole inputRole)
        {
            var role = _mapper.Map<Role>(inputRole);
            return await _userRepository.CorrectRoleByIdAsyns(id, role);
        }

        public async Task<User> CorrectUserAsyns(long id, InputUser inputUser)
        {
            var currentUserId = _currentUserService.GetUserId();
            var currentRole = _currentUserService.GetUserRole();
            if (!((currentRole == RoleConst.admin) || (currentUserId == id))) throw new UnauthorizedAccessException("У вас нет прав для изменения этого пользователя.");

            var user = _mapper.Map<User>(inputUser);
            if (!string.IsNullOrEmpty(inputUser.password))
            {
                user.PasswordHash = _passwordHashService.GenerateHash(inputUser.password);
            }

            var currentUserId = _currentUserService.GetUserId();
            var currentRole = _currentUserService.GetUserRole();
            if (currentRole == Consts.RoleConst.admin) { return await _userRepository.CorrectUserByIdAsyns(id, user); }
            else if (currentUserId == id) { return await _userRepository.CorrectUserByIdAsyns(id, user); }
            throw new UnauthorizedAccessException("У вас нет прав для удаления этого пользователя.");
        }

        public async Task<bool> DeleteFamilyByIdAsyns(long id)
        {
            var userId = _currentUserService.GetUserId();
            var userRole = _currentUserService.GetUserRole();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");
            
            if (!(familyId == id || userRole == RoleConst.admin)) throw new UnauthorizedAccessException("У вас нет прав для удаления этого пользователя.");

            return await _userRepository.DeleteFamilyByIdAsyns(id);
        }

        public async Task<bool> DeleteRoleByIdAsyns(long id)
        {
            return await _userRepository.DeleteRoleByIdAsyns(id);
        }

        public async Task<bool> DeleteUserByIdAsyns(long id)
        {
            var currentUserId = _currentUserService.GetUserId();
            var currentRole = _currentUserService.GetUserRole();
            if (!((currentRole == RoleConst.admin) || (currentUserId == id))) throw new UnauthorizedAccessException("У вас нет прав для удаления этого пользователя."); 
            return await _userRepository.DeleteUserByIdAsync(id);
        }

        public async Task<string> GenerateHash(string password)
        {
            return _passwordHashService.GenerateHash(password);
        }

        public async Task<IEnumerable<Family>> GetFamiliesAsync()
        {
            var families = await _userRepository.GetAllFamilyAsync();
            if (families is null) throw new Exception("Users not found");
            return families;
        }

        public async Task<Family> GetFamilyByIdAsync(long id)
        {
            var family = await _userRepository.GetFamilyByIdAsync(id);
            if (family is null) throw new Exception("Family not found");
            return family;
        }

        public async Task<Family> GetFamilyByUserIdAsync(long id)
        {
            var family = await _userRepository.GetFamilyByUserIdAsync(id);
            if (family is null) throw new Exception("Family not found");
            return family;
        }

        public async Task<Role> GetRoleByIdAsync(long id)
        {
            var role = await _userRepository.GetRoleByIdAsync(id);
            if (role is null) throw new Exception("Role not found");
            return role;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var roles = await _userRepository.GetAllRoleAsync();
            if (roles is null) throw new Exception("Roles not found");
            return roles;
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            var userId = _currentUserService.GetUserId();
            var userRole = _currentUserService.GetUserRole();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            //список ид в семье пользователя который авторизован
            var usersByFamily = await _userRepository.GetUsersIdByFamilyAsync(familyId);

            if (!(usersByFamily.Contains(id) || userRole == RoleConst.admin)) throw new UnauthorizedAccessException("У вас нет прав для просмотра этого пользователя.");

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user is null) throw new Exception("User not found");

            if (userRole == RoleConst.admin) return user;

            if ((RoleConst)Enum.ToObject(typeof(RoleConst), user.RoleId) == RoleConst.admin) throw new UnauthorizedAccessException("У вас нет прав для просмотра этого пользователя.");

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var user = await _userRepository.GetAllUsersAsync();
            if (user is null) throw new Exception("Users not found");
            return user;
        }

        #region Virify
        public async Task Login(LoginInput loginInput)
        {
            User? user;
            if (!(loginInput.telegramId <= 0 || loginInput.telegramId is null))
            {
                long telegramId = (long)loginInput.telegramId;
                user = await _userRepository.GetUserByTelegramIdAsync(telegramId);
            }
            else if (!(string.IsNullOrEmpty(loginInput.email)))
            {
                user = await _userRepository.GetUserByEmailAsync(loginInput.email);
            }
            else throw new Exception("User not found");

            var passwordHash = await _userRepository.GetHashByUserIdAsync(user.UserId);
            var checkVerify = _passwordHashService.Verify(passwordHash, loginInput.password);

            if (checkVerify)
            {
                var token = _jwtProvider.GenerateToken(user);
                _context.HttpContext.Response.Cookies.Append("litle_baby" ,token);
                return;
            }
            throw new Exception("Password incorect");
        }

        public Task Logout()
        {
            //TODO: отзывать токен
            _context.HttpContext.Response.Cookies.Delete("litle_baby");
            return Task.CompletedTask;
        }

        #endregion Virify
        #endregion

        #region private
        private async Task AddDefaultCategoryInFamily(long familiId)
        {
            var listDefBudgerCategory = await _budgerRepository.GetDefaultBudgerCategoryAsyns();
            var listBudgerCategory = _mapper.Map<IEnumerable<BudgerCategory>>(listDefBudgerCategory);

            var listDefIncomCategory = await _budgerRepository.GetDefaultIncomCategoryAsyns();
            var listIncomCategory = _mapper.Map<IEnumerable<IncomCategory>>(listDefIncomCategory);

            await _budgerRepository.AddBudgerCategoryInFamilyAsyns(familiId, listBudgerCategory);
            await _budgerRepository.AddIncomCategoryInFamilyAsyns(familiId, listIncomCategory);
        }
        #endregion
    }
}
