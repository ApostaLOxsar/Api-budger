using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;
using Api_budger.Services.Abstractions;

namespace Api_budger.Controllers
{
    [Route("Budger")]
    [ApiController]
    public class BudgerController : ControllerBase
    {
        private readonly ILogger<BudgerController> _logger;
        private readonly IBudgerService _budgerService;
        public BudgerController(ILogger<BudgerController> logger, IBudgerService budgerService)
        {
            _logger = logger;
            _budgerService = budgerService;
        }

        [HttpGet]
        [Route("GetBudgerByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Budger>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Budger>> GetBudgerByFamilyId(long familyId)
        {
            var listBudger = await _budgerService.GetBudgerByFamilyIdAsyns(familyId);
            return listBudger;
        }

        [HttpGet]
        [Route("GetBudgerByUser/{useryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Budger>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Budger>> GetBudgerByUserId(long useryId)
        {
            var budger = await _budgerService.GetBudgerByUserIdAsyns(useryId);
            return budger;
        }

        [HttpPost]
        [Route("AddBudger")]
        [ProducesResponseType(200, Type = typeof(Budger))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Budger> AddBudger(InputBudger inputBudger)
        {
            var newBudger = await _budgerService.AddBudgerAsyns(inputBudger);
            return newBudger;
        }

        [HttpDelete]
        [Route("DeleteBudger/{budgerId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteBudgerById(long budgerId)
        {
            return await _budgerService.DeleteBudgerByIdAsyns(budgerId);
        }

        [HttpPut]
        [Route("CorrectBudger")]
        [ProducesResponseType(200, Type = typeof(Budger))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Budger> CorrectBudger(long Id, InputBudger inputBudger)
        {
            var budger = await _budgerService.CorrectBudgerAsyns(Id, inputBudger);
            return budger;
        }
    }
}
