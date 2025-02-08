using System;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

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
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            List<long> listUser = new List<long>();

            //TODO: рефактор логики (возможно когда 1 из списка подходит то if пропустит все остальные)
            foreach (var budgerCategory in inputBudger)
            {
                listUser.AddRange(await _budgerRepository.GetUserIdByBudgerCategoryId(budgerCategory.BudgerCategoriyId));
            }
            listUser = (List<long>)listUser.Distinct();


            if (!listUser.Any(u => u == userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления расходов этой семьи.");
            }


            var budger = _mapper.Map<IEnumerable<Budger>>(inputBudger);
            var date = DateTime.UtcNow;

            budger.ToList().ForEach(b => b.Date = date);
            budger.ToList().ForEach(u => u.UserId = userId);

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

        public async Task<IEnumerable<Incom>> AddIncomsAsyns(IEnumerable<InputIncom> inputIncom)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            List<long> listUser = new List<long>();

            //TODO: рефактор логики (возможно когда 1 из списка подходит то if пропустит все остальные)
            foreach (var incomCategory in inputIncom)
            {
                listUser.AddRange(await _budgerRepository.GetUserIdByIncomCategoryId(incomCategory.IncomeCategoryId));
            }
            listUser = (List<long>)listUser.Distinct();


            if (!listUser.Any(u => u == userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления доходов этой семьи.");
            }


            var incoms = _mapper.Map<IEnumerable<Incom>>(inputIncom);
            var date = DateTime.UtcNow;

            incoms.ToList().ForEach(b => b.Date = date);
            incoms.ToList().ForEach(u => u.UserId = userId);

            var result = await _budgerRepository.AddIncomsAsyns(incoms);
            return result;
        }

        public async Task<IEnumerable<IncomCategory>> AddIncomCategoryInFamilyAsyns(IEnumerable<InputIncomCategory> inputIncomCategory)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var incomCategoryList = _mapper.Map<IEnumerable<IncomCategory>>(inputIncomCategory);
            var result = await _budgerRepository.AddIncomCategoryInFamilyAsyns(familyId, incomCategoryList);
            return result;
        }

        public async Task<Budger> CorrectBudgerAsyns(long id, InputBudger inputBudger)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var userIdByBC = await _budgerRepository.GetUserIdByBudgerCategoryId(id);

            if (!userIdByBC.Contains(userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления расходов этой семьи.");
            }

            var newBudger = _mapper.Map<Budger>(inputBudger);
            var result = await _budgerRepository.CorrectBudgerAsyns(id, newBudger);
            if (result is null) throw new Exception("New budger incorrect");
            return result;
        }

        public async Task<BudgerCategory> CorrectBudgerCategoryFromUserByIdAsyns(long id, InputBudgerCategory inputBudgerCategory)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdByBudgerCategoryId(id);

            if (!userIdByBudgerCategoryId.Any(u => u == userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления категорий доходов этой семьи.");
            }

            var budgerCategory = _mapper.Map<BudgerCategory>(inputBudgerCategory);

            var result = await _budgerRepository.CorrectBudgerCategoryFromUserByIdAsyns(id, userId, budgerCategory);
            if (result is null) throw new Exception("Новая категория расходов не корректна или не верна");
            return result;
        }

        public async Task<Incom> CorrectIncomAsyns(long id, InputIncom inputIncom)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var userIdByIC = await _budgerRepository.GetUserIdByIncomCategoryId(id);

            if (!userIdByIC.Contains(userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления категорий доходов этой семьи.");
            }

            var newIncom = _mapper.Map<Incom>(inputIncom);
            var result = await _budgerRepository.CorrectIncomAsyns(id, newIncom);
            if (result is null) throw new Exception("New incom incorrect");
            return result;
        }

        public async Task<IncomCategory> CorrectIncomCategoryFromUserByIdAsyns(long id, InputIncomCategory inputIncomCategory)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdByIncomCategoryId(id);

            if (!userIdByBudgerCategoryId.Any(u => u == userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления категорий доходов этой семьи.");
            }

            var newIncomCategory = _mapper.Map<IncomCategory>(inputIncomCategory);

            var result = await _budgerRepository.CorrectIncomCategoryFromUserByIdAsyns(id, userId, newIncomCategory);
            if (result is null) throw new Exception("Новая категория доходов не корректна или не верна");
            return result;
        }

        public async Task<bool> DeleteBudgerByIdAsyns(long budgerId)
        {
            var currentUserId = _currentUserService.GetUserId();
            if (currentUserId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(currentUserId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdsByBydgerIdAsyns(budgerId);
            if (userIdByBudgerCategoryId.IsNullOrEmpty()) throw new KeyNotFoundException("Пользователь не найден");

            if (!(userIdByBudgerCategoryId.Contains(currentUserId)))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления расходов этой семьи.");
            }

            return await _budgerRepository.DeleteBudgerByIdAsyns(budgerId);
        }

        public async Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdByBudgerCategoryId(budgerCategoryId);

            if (!userIdByBudgerCategoryId.Any(u => u == userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления категорий доходов этой семьи.");
            }

            return await _budgerRepository.DeleteBudgerCategoryFromFamilyByIdAsyns(budgerCategoryId, familyId);
        }

        public async Task<bool> DeleteIncomByIdAsyns(long incomId)
        {
            var currentUserId = _currentUserService.GetUserId();
            if (currentUserId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(currentUserId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdsByIncomIdAsyns(incomId);
            if (userIdByBudgerCategoryId.IsNullOrEmpty()) throw new KeyNotFoundException("Пользователь не найден");

            if (!(userIdByBudgerCategoryId.Contains(currentUserId)))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления доходов этой семьи.");
            }

            return await _budgerRepository.DeleteIncomByIdAsyns(incomId);
        }

        public async Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId)
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найдена");

            var userIdByBudgerCategoryId = await _budgerRepository.GetUserIdByIncomCategoryId(incomCategoryId);

            if (!userIdByBudgerCategoryId.Any(u => u == userId))
            {
                throw new UnauthorizedAccessException("У вас нет прав для удаления категорий доходов этой семьи.");
            }

            return await _budgerRepository.DeleteIncomCategoryFromFamilyByIdAsyns(incomCategoryId, familyId);
        }

        public async Task<IEnumerable<Budger>> GetBudgerByFamilyIdAsyns()
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найден");

            var result = await _budgerRepository.GetBudgerByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("Расходы пусты");
            return result;
        }

        public async Task<IEnumerable<Budger>> GetBudgerByUserIdAsyns()
        {
            var cyrrentUserId = _currentUserService.GetUserId();
            if (cyrrentUserId <= 0) throw new KeyNotFoundException("Пользователь не найден");

            var result = await _budgerRepository.GetBudgerByUserIdAsyns(cyrrentUserId);
            if (result is null) throw new Exception("Расходы пусты");
            return result;
        }

        public async Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyIdAsyns()
        {
            var userId = _currentUserService.GetUserId();
            if (userId <= 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);

            var result = await _budgerRepository.GetBudgerCategoryByFamilyIdAsyns(familyId);
            if (result is null) throw new KeyNotFoundException("Категории расходов пуста");
            return result;
        }

        public async Task<IEnumerable<Incom>> GetIncomByFamilyIdAsyns()
        {
            var userId = _currentUserService.GetUserId();
            if (userId == 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);
            if (familyId <= 0) throw new KeyNotFoundException("Семья не найден");

            var result = await _budgerRepository.GetIncomByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("Доходы пусты");
            return result;
        }

        public async Task<IEnumerable<Incom>> GetIncomByUserIdAsyns()
        {
            var cyrrentUserId = _currentUserService.GetUserId();
            if (cyrrentUserId <= 0) throw new KeyNotFoundException("Пользователь не найден");

            var result = await _budgerRepository.GetIncomByUserIdAsyns(cyrrentUserId);
            if (result is null) throw new Exception("Доходы пусты");
            return result;
        }

        public async Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyIdAsyns()
        {
            var userId = _currentUserService.GetUserId();
            if (userId <= 0) throw new KeyNotFoundException("Пользователь не найден");

            var familyId = await _userRepository.GetFamilyIdByUserIdAsync(userId);

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
