using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
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
        public BudgerService(ILogger<BudgerService> logger, IUserRepository userRepository, IBudgerRepository budgerRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _budgerRepository = budgerRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Budger>> AddBudgersAsyns(ICollection<InputBudger> inputBudger)
        {
            var budger = _mapper.Map<ICollection<Budger>>(inputBudger);
            var result = await _budgerRepository.AddBudgersAsyns(budger);
            return result;
        }

        public async Task<ICollection<BudgerCategory>> AddBudgerCategoryInFamilyAsyns(ICollection<InputBudgerCategory> inputBudger)
        {
            var budgerCategoryList = _mapper.Map<ICollection<BudgerCategory>>(inputBudger);
            var result = await _budgerRepository.AddBudgerCategoryInFamilyAsyns(budgerCategoryList);
            return result;
        }

        public Task<ICollection<Incom>> AddIncomAsyns(ICollection<InputIncom> inputIncom)
        {
            var incom = _mapper.Map<ICollection<Incom>>(inputIncom);
            var result = _budgerRepository.AddIncomsAsyns(incom);
            return result;
        }

        public async Task<ICollection<IncomCategory>> AddIncomCategoryInFamilyAsyns(ICollection<InputIncomCategory> inputIncomCategory)
        {
            var incomCategoryList = _mapper.Map<ICollection<IncomCategory>>(inputIncomCategory);
            var result = await _budgerRepository.AddIncomCategoryInFamilyAsyns(incomCategoryList);
            return result;
        }

        public async Task<Budger> CorrectBudgerAsyns(long id, InputBudger inputBudger)
        {
            var newBudger = _mapper.Map<Budger>(inputBudger);
            var result = await _budgerRepository.CorrectBudgerAsyns(id, newBudger);
            if (result is null) throw new Exception("New budger incorrect");
            return result;
        }

        public async Task<BudgerCategory> CorrectBudgerCategoryFromUserByIdAsyns(long id, long userId, InputBudgerCategory inputBudgerCategory)
        {
            var budgerCategory = _mapper.Map<BudgerCategory>(inputBudgerCategory);
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

        public async Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId, long familyId)
        {
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
            if (result is null) throw new Exception("budger empty");
            return result;
        }

        public async Task<IEnumerable<Budger>> GetBudgerByUserIdAsyns(long useryId)
        {
            var result = await _budgerRepository.GetBudgerByUserIdAsyns(useryId);
            if (result is null) throw new Exception("budger empty");
            return result;
        }

        public async Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyIdAsyns(long familyId)
        {
            var result = await _budgerRepository.GetBudgerCategoryByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("budger category empty");
            return result;
        }

        public async Task<IEnumerable<Incom>> GetIncomByFamilyIdAsyns(long familyId)
        {
            var result = await _budgerRepository.GetIncomByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("incom empty");
            return result;
        }

        public async Task<IEnumerable<Incom>> GetIncomByUserIdAsyns(long useryId)
        {
            var result = await _budgerRepository.GetIncomByUserIdAsyns(useryId);
            if (result is null) throw new Exception("incom empty");
            return result;
        }

        public async Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyIdAsyns(long familyId)
        {
            var result = await _budgerRepository.GetIncomCategoryByFamilyIdAsyns(familyId);
            if (result is null) throw new Exception("incom category empty");
            return result;
        }
    }
}
