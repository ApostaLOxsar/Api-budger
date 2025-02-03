﻿using System.Net;
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
        private readonly ICurentUserService _curentUserService;
        public ClientService(ILogger<ClientService> logger,
                             IUserRepository userRepository,
                             IBudgerRepository budgerRepository,
                             IMapper mapper,
                             IPasswordHashService passwordHashService,
                             IJwtProvider jwtProvider,
                             IHttpContextAccessor httpContext,
                             ICurentUserService curentUserService)
        {
            _jwtProvider = jwtProvider;
            _logger = logger;
            _userRepository = userRepository;
            _budgerRepository = budgerRepository;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
            _context = httpContext;
            _curentUserService = curentUserService;
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

        public async Task<Family> CorrectFamilyAsyns(long id, InputFamily inputFamily)
        {
            var famili = _mapper.Map<Family>(inputFamily);
            return await _userRepository.CorrectFamilyByIdAsyns(id, famili);
        }

        public async Task<Role> CorrectRoleAsyns(long id, InputRole inputRole)
        {
            var role = _mapper.Map<Role>(inputRole);
            return await _userRepository.CorrectRoleByIdAsyns(id, role);
        }

        public async Task<User> CorrectUserAsyns(long id, InputUser inputUser)
        {
            var user = _mapper.Map<User>(inputUser);
            if (!string.IsNullOrEmpty(inputUser.password))
            {
                user.PasswordHash = _passwordHashService.GenerateHash(inputUser.password);
            }
            return await _userRepository.CorrectUserByIdAsyns(id, user);
        }

        public async Task<bool> DeleteFamilyByIdAsyns(long id)
        {
            return await _userRepository.DeleteFamilyByIdAsyns(id);
        }

        public async Task<bool> DeleteRoleByIdAsyns(long id)
        {
            return await _userRepository.DeleteRoleByIdAsyns(id);
        }

        public async Task<bool> DeleteUserByIdAsyns(long id)
        {
            var currentUserId = _curentUserService.GetUserId();
            var currentRole = _curentUserService.GetUserRole();
            if (currentRole == Consts.RoleConst.admin) { return await _userRepository.DeleteUserByIdAsync(id); }
            else if (currentUserId == id) { return await _userRepository.DeleteUserByIdAsync(id); }
            throw new UnauthorizedAccessException("У вас нет прав для удаления этого пользователя.");
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
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user is null) throw new Exception("User not found");
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
                user = await _userRepository.GetUserByTelegramId(telegramId);
            }
            else if (!(string.IsNullOrEmpty(loginInput.email)))
            {
                user = await _userRepository.GetUserByEmail(loginInput.email);
            }
            else throw new Exception("User not found");

            var passwordHash = await _userRepository.GetHashByUserId(user.UserId);
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
