using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Services.Abstractions;

namespace Api_budger.Controllers
{
    [Route("BudgerCategory")]
    [ApiController]
    public class BudgerCategoryController : ControllerBase
    {
        private readonly ILogger<BudgerCategoryController> _logger;
        private readonly IBudgerService _budgerService;
        public BudgerCategoryController(ILogger<BudgerCategoryController> logger, IBudgerService budgerService)
        {
            _logger = logger;
            _budgerService = budgerService;
        }


        [HttpGet]
        [Route("GetBudgerCategoryByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BudgerCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<BudgerCategory>> GetBudgerCategoryByFamilyId(long familyId)
        {
            var budgerCategories = await _budgerService.GetBudgerCategoryByFamilyIdAsyns(familyId);
            return budgerCategories;
        }

        [HttpPost]
        [Route("AddBudgerCategoryInFamily")]
        [ProducesResponseType(200, Type = typeof(BudgerCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<BudgerCategory> AddBudgerCategoryInFamily(InputBudgerCategory inputBudger)
        {
            var budgerCategory = await _budgerService.AddBudgerCategoryInFamilyAsyns(inputBudger);
            return budgerCategory;
        }

        [HttpDelete]
        [Route("DeleteBudgerCategoryFromFamily/{budgerCategoryId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteBudgerCategoryFromFamilyById(long budgerCategoryId, long familyId)
        {
            return await _budgerService.DeleteBudgerCategoryFromFamilyByIdAsyns(budgerCategoryId, familyId);
        }

        [HttpPut]
        [Route("CorrectBudgerCategoryFromUser/{id}")]
        [ProducesResponseType(200, Type = typeof(BudgerCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<BudgerCategory> CorrectBudgerCategoryFromUserById(long id, long userId, InputBudgerCategory inputBudgerCategory)
        {
            var budgerCategory = await _budgerService.CorrectBudgerCategoryFromUserByIdAsyns(id, userId, inputBudgerCategory);
            return budgerCategory;
        }
    }
}
