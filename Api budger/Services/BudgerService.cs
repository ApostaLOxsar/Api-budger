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


        public Task<Budger> AddBudgerAsyns(InputBudger inputBudger)
        {
            throw new NotImplementedException();
        }

        public Task<BudgerCategory> AddBudgerCategoryInFamilyAsyns(InputBudgerCategory inputBudger)
        {
            throw new NotImplementedException();
        }

        public Task<Incom> AddIncomAsyns(InputIncom inputIncom)
        {
            throw new NotImplementedException();
        }

        public Task<IncomCategory> AddIncomCategoryInFamilyAsyns(InputIncomCategory inputIncomCategory)
        {
            throw new NotImplementedException();
        }

        public Task<Budger> CorrectBudgerAsyns(long Id, InputBudger inputBudger)
        {
            throw new NotImplementedException();
        }

        public Task<BudgerCategory> CorrectBudgerCategoryFromUserByIdAsyns(long id, long userId, InputBudgerCategory inputBudgerCategory)
        {
            throw new NotImplementedException();
        }

        public Task<Incom> CorrectIncomAsyns(long Id, InputIncom inputIncom)
        {
            throw new NotImplementedException();
        }

        public Task<IncomCategory> CorrectIncomCategoryFromUserByIdAsyns(long Id, long userId, InputIncomCategory inputIncomCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBudgerByIdAsyns(long budgerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBudgerCategoryFromFamilyByIdAsyns(long budgerCategoryId, long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIncomByIdAsyns(long incomId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIncomCategoryFromFamilyByIdAsyns(long incomCategoryId, long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Budger>> GetBudgerByFamilyIdAsyns(long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Budger>> GetBudgerByUserIdAsyns(long useryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyIdAsyns(long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Incom>> GetIncomByFamilyIdAsyns(long familyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Incom>> GetIncomByUserIdAsyns(long useryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyIdAsyns(long familyId)
        {
            throw new NotImplementedException();
        }
    }
}
