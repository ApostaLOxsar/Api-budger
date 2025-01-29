using Api_budger.Models.budgers;
using Api_budger.Models.input;
using Api_budger.Models.output;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
{
    [Authorize]
    [Route("DefaultCategory")]
    [ApiController]
    public class DefaultCategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBudgerService _budgerService;
        private readonly ILogger<DefaultCategoriesController> _logger;

        public DefaultCategoriesController(IMapper mapper, IBudgerService budgerService, ILogger<DefaultCategoriesController> logger)
        {
            _mapper = mapper;
            _budgerService = budgerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetDefaultIncomCategories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DefaultIncomeCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<DefaultIncomeCategory>> GetDefaultIncomCategories()
        {
            var result = await _budgerService.GetDefaultIncomCategory();
            return result;
        }

        [HttpPost]
        [Route("AddDefaultIncomCategory")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> AddDefaultIncomCategory(IEnumerable<InputIncomCategory> inputIncomCategory)
        {
            var incomCategories = _mapper.Map<IEnumerable<DefaultIncomeCategory>>(inputIncomCategory);
            await _budgerService.AddDefaultIncomCategory(incomCategories);
            return true;
        }

        [HttpDelete]
        [Route("DeleteDefaultIncomCategory")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteDefaultIncomCategory(long id)
        {
            return await _budgerService.DeleteDefaultIncomCategoryAsyns(id);
        }

        [HttpGet]
        [Route("GetDefaultBudgerCategory")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DefaultBudgerCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<DefaultBudgerCategory>> GetDefaultBudgerCategory()
        {
            var result = await _budgerService.GetDefaultBudgerCategory();
            return result;
        }

        [HttpPost]
        [Route("AddDefaultBudgerCategory")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> AddDefaultBudgerCategory(IEnumerable<InputBudgerCategory> inputBudgerCategories)
        {
            var budgerCategories = _mapper.Map<IEnumerable<DefaultBudgerCategory>>(inputBudgerCategories);
            await _budgerService.AddDefaultBudgerCategory(budgerCategories);
            return true;
        }

        [HttpDelete]
        [Route("DeleteDefaultBudgerCategory")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteDefaultBudgerCategory(long id)
        {
            return await _budgerService.DeleteDefaultIncomCategoryAsyns(id);
        }
    }
}
