using System;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Api_budger.Services.Abstractions;
using AutoMapper;

namespace Api_budger.Services
{
    public class BudgerService : IBudgerService
    {
        private readonly ILogger<BudgerService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IBudgerRepository _budgerRepository;
        private readonly IMapper _mapper;
        private readonly ICurentUserService _currentUserService;
        public BudgerService(ILogger<BudgerService> logger,
                             IUserRepository userRepository,
                             IBudgerRepository budgerRepository,
                             IMapper mapper,
                             ICurentUserService curentUserService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _budgerRepository = budgerRepository;
            _mapper = mapper;
            _currentUserService = curentUserService;
        }

        #region public
        public async Task<IEnumerable<Budger>> AddBudgersAsyns(IEnumerable<InputBudger> inputBudger)
        {
            var budger = _mapper.Map<IEnumerable<Budger>>(inputBudger);
            var date = DateTime.UtcNow;
            budger.ToList().ForEach(b => b.Date = date);
            var result = await _budgerRepository.AddBudgersAsyns(budger);
            return result;
        }

        public async Task<IEnumerable<BudgerCategory>> AddBudgerCategoryInFamilyAsyns(IEnumerable<InputBudgerCategory> inputBudger)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var budgerCategoryList = _mapper.Map<IEnumerable<BudgerCategory>>(inputBudger);
            var result = await _budgerRepository.AddBudgerCategoryInFamilyAsyns(familyId, budgerCategoryList);
            return result;
        }

        public Task<IEnumerable<Incom>> AddIncomsAsyns(IEnumerable<InputIncom> inputIncom)
        {
            var incom = _mapper.Map<IEnumerable<Incom>>(inputIncom);
            var date = DateTime.UtcNow;
            incom.ToList().ForEach(b => b.Date = date);
            var result = _budgerRepository.AddIncomsAsyns(incom);
            return result;
        }

        public async Task<IEnumerable<IncomCategory>> AddIncomCategoryInFamilyAsyns(IEnumerable<InputIncomCategory> inputIncomCategory)
        {
            long familiId = -1;
            if (familiId <= 0) throw new Exception("famili Id <= 0");
            var incomCategoryList = _mapper.Map<IEnumerable<IncomCategory>>(inputIncomCategory);
            var result = await _budgerRepository.AddIncomCategoryInFamilyAsyns(familiId, incomCategoryList);
            return result;
        }

        public async Task<Budger> CorrectBudgerAsyns(long id, InputBudger inputBudger)
        {
            var newBudger = _mapper.Map<Budger>(inputBudger);
            var result = await _budgerRepository.CorrectBudgerAsyns(id, newBudger);
            if (result is null) throw new Exception("New budger incorrect");
            return result;
        }

        public async Task<BudgerCategory> CorrectBudgerCategoryFromUserByIdAsyns(long id, InputBudgerCategory inputBudgerCategory)
        {
            var budgerCategory = _mapper.Map<BudgerCategory>(inputBudgerCategory);

            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var result = await _budgerRepository.CorrectBudgerCategoryFromUserByIdAsyns(id, userId, budgerCategory);
            if (result is null) throw new Exception("New budger category incorrect");
            return result;
        }

        public async Task<Incom> CorrectIncomAsyns(long id, InputIncom inputIncom)
        {
            var incom = _mapper.Map<Incom>(inputIncom);
            var result = await _budgerRepository.CorrectIncomAsyns(id, incom);
            if (result is null) throw new Exception("New incom incorrect");
            return result;
        }

        public async Task<IncomCategory> CorrectIncomCategoryFromUserByIdAsyns(long id, long userId, InputIncomCategory inputIncomCategory)
        {
            var newIncomCategory = _mapper.Map<IncomCategory>(inputIncomCategory);
            var result = await _budgerRepository.CorrectIncomCategoryFromUserByIdAsyns(id, userId, newIncomCategory);
            if (result is null) throw new Exception("New incom category incorrect");
            return result;
        }

        public async Task<bool> DeleteBudgerByIdAsyns(long budgerId)
        {
            return await _budgerRepository.DeleteBudgerByIdAsyns(budgerId);
        }

        public async Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId)
        {
            var userId = _currentUserService.GetUserId();
            var userRole = _currentUserService.GetUserRole();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdByBudgerCategoryId(budgerCategoryId);

            if (!(userIdByBudgerCategoryId.Any(u => u == userId) || userRole == Consts.RoleConst.admin))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления категорий доходов этой семьи.");
            }

            return await _budgerRepository.DeleteBudgerCategoryFromFamilyByIdAsyns(budgerCategoryId, familyId);
        }

        public async Task<bool> DeleteIncomByIdAsyns(long incomId)
        {
            return await _budgerRepository.DeleteIncomByIdAsyns(incomId);
        }

        public async Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId, long familyId)
        {
            return await _budgerRepository.DeleteIncomCategoryFromFamilyByIdAsyns(incomCategoryId, familyId);
        }

        public async Task<IEnumerable<Budger>> GetBudgerByFamilyIdAsyns(long familyId)
        {
            var result = await _budgerRepository.GetBudgerByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("Расходы пусты");
            return result;
        }

        public async Task<IEnumerable<Budger>> GetBudgerByUserIdAsyns(long useryId)
        {
            var result = await _budgerRepository.GetBudgerByUserIdAsyns(useryId);
            if (result is null) throw new Exception("Расходы пусты");
            return result;
        }

        public async Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyIdAsyns(long familyId)
        {

            var userIdByFamily = await _userRepository.GetUserIdByFamilyAsync(familyId);
            var userId = _currentUserService.GetUserId();
            if (userIdByFamily == 0) throw new KeyNotFoundException("User not found");
            var userRole = _currentUserService.GetUserRole();

            if (!(userId == userIdByFamily || userRole == Consts.RoleConst.admin))
            {
                throw new UnauthorizedAccessException("У вас нет прав для просмотра категорий расходов этой семьи.");
            }

            var result = await _budgerRepository.GetBudgerCategoryByFamilyIdAsyns(familyId);
            if (result is null) throw new KeyNotFoundException("Категории расходов пуста");
            return result;
        }

        public async Task<IEnumerable<Incom>> GetIncomByFamilyIdAsyns(long familyId)
        {
            var userIdByFamily = await _userRepository.GetUserIdByFamilyAsync(familyId);
            var userId = _currentUserService.GetUserId();
            if (userIdByFamily == 0) throw new KeyNotFoundException("User not found");
            var userRole = _currentUserService.GetUserRole();

            if (!(userId == userIdByFamily || userRole == Consts.RoleConst.admin))
            {
                throw new UnauthorizedAccessException("У вас нет прав для просмотра доходов этой семьи.");
            }

            var result = await _budgerRepository.GetIncomByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("Доходы пусты");
            return result;
        }

        public async Task<IEnumerable<Incom>> GetIncomByUserIdAsyns(long userId)
        {
            var cyrrentUserId = _currentUserService.GetUserId();
            if (cyrrentUserId == 0) throw new KeyNotFoundException("User not found");
            var userRole = _currentUserService.GetUserRole();

            if (!(userId == cyrrentUserId || userRole == Consts.RoleConst.admin))
            {
                throw new UnauthorizedAccessException("У вас нет прав для просмотра доходов этого пользователя");
            }

            var result = await _budgerRepository.GetIncomByUserIdAsyns(userId);
            if (result is null) throw new Exception("Доходы пусты");
            return result;
        }

        public async Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyIdAsyns(long familyId)
        {
            var userIdByFamily = await _userRepository.GetUserIdByFamilyAsync(familyId);
            var userId = _currentUserService.GetUserId();
            if (userIdByFamily == 0) throw new KeyNotFoundException("User not found");
            var userRole = _currentUserService.GetUserRole();

            if (!(userId == userIdByFamily || userRole == Consts.RoleConst.admin))
            {
                throw new UnauthorizedAccessException("У вас нет прав для просмотра категории доходов этой семьи.");
            }

            var result = await _budgerRepository.GetIncomCategoryByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("Категория доходов пуста");
            return result;
        }

        public async Task<IEnumerable<DefaultIncomeCategory>> GetDefaultIncomCategory()
        {
            var defaultIncomeCategories = await _budgerRepository.GetDefaultIncomCategoryAsyns();
            return defaultIncomeCategories;
        }

        public async Task<IEnumerable<DefaultBudgerCategory>> GetDefaultBudgerCategory()
        {
            var defaultBudgerCategories = await _budgerRepository.GetDefaultBudgerCategoryAsyns();
            return defaultBudgerCategories;
        }

        public Task AddDefaultIncomCategory(IEnumerable<DefaultIncomeCategory> incomCategory)
        {
            return _budgerRepository.AddDefaultIncomCategoryAsyns(incomCategory);
        }

        public Task AddDefaultBudgerCategory(IEnumerable<DefaultBudgerCategory> budgerCategory)
        {
            return _budgerRepository.AddDefaultBudgerCategoryAsyns(budgerCategory);
        }

        public async Task<bool> DeleteDefaultIncomCategoryAsyns(long id)
        {
            return await _budgerRepository.DeleteDefaultIncomCategoryAsyns(id);
        }

        public async Task<bool> DeleteDefaultBudgerCategory(long id)
        {
            return await _budgerRepository.DeleteDefaultBudgerCategoryAsyns(id);
        }
        #endregion

        #region private


        #endregion
    }
}
