using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;

namespace Api_budger.Controllers
{
    [Route("BudgerCategory")]
    [ApiController]
    public class BudgerCategoryController : ControllerBase
    {
        private readonly ILogger<BudgerCategoryController> _logger;
        public BudgerCategoryController(ILogger<BudgerCategoryController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("GetBudgerCategoryByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BudgerCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<BudgerCategory>> GetBudgerByFamilyId(long familyId)
        {
            return new List<BudgerCategory>
            {
            };
        }

        [HttpPost]
        [Route("AddBudgerCategory")]
        [ProducesResponseType(200, Type = typeof(BudgerCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<BudgerCategory> AddBudger(InputBudgerCategory inputBudger)
        {
            return new BudgerCategory
            {

            };
        }

        [HttpDelete]
        [Route("DeleteBudgerCategory/{BudgerCategoryId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteBudgerById(long BudgerCategoryId)
        {
            return true;
        }

        [HttpPut]
        [Route("CorrectBudgerCategory")]
        [ProducesResponseType(200, Type = typeof(BudgerCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<BudgerCategory> CorrectBudger(long Id, InputBudgerCategory inputBudgerCategory)
        {
            return new BudgerCategory
            {
            };
        }
    }
}
