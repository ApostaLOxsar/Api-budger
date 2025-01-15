using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
{
    [Route("IncomCategory")]
    [ApiController]
    public class IncomCategoryController : ControllerBase
    {
        private readonly ILogger<IncomCategoryController> _logger;
        private readonly IBudgerService _budgerService;
        public IncomCategoryController(ILogger<IncomCategoryController> logger, IBudgerService budgerService)
        {
            _logger = logger;
            _budgerService = budgerService;
        }

        [HttpGet]
        [Route("GetIncomCategoryByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IncomCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<IncomCategory>> GetIncomCategoryByFamilyId(long familyId)
        {
            var incomCategories = await _budgerService.GetIncomCategoryByFamilyIdAsyns(familyId);
            return incomCategories;
        }

        [HttpPost]
        [Route("AddIncomCategoryInFamily")]
        [ProducesResponseType(200, Type = typeof(IncomCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IncomCategory> AddIncomCategoryInFamily(InputIncomCategory inputIncomCategory)
        {
            var newIncomCategory = await _budgerService.AddIncomCategoryInFamilyAsyns(inputIncomCategory);
            return newIncomCategory;
        }

        [HttpDelete]
        [Route("DeleteIncomCategoryFromFamily/{incomCategoryId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteIncomCategoryFromFamilyById(long incomCategoryId, long familyId)
        {
            return await _budgerService.DeleteIncomCategoryFromFamilyByIdAsyns(incomCategoryId,familyId);
        }

        [HttpPut]
        [Route("CorrectIncomCategoryFromUser/{id}")]
        [ProducesResponseType(200, Type = typeof(IncomCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IncomCategory> CorrectIncomCategoryFromUserById(long id, long userId, InputIncomCategory inputIncomCategory)
        {
            var correctIncomCategory = await _budgerService.CorrectIncomCategoryFromUserByIdAsyns(id, userId, inputIncomCategory);
            return correctIncomCategory;
        }
    }
}
