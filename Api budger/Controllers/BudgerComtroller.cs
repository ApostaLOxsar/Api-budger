using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;

namespace Api_budger.Controllers
{
    [Route("Budger")]
    [ApiController]
    public class BudgerController : ControllerBase
    {
        private readonly ILogger<BudgerController> _logger;
        public BudgerController(ILogger<BudgerController> logger)
        {
            _logger = logger;
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
            return new List<Budger>
            {
            };
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
            return new List<Budger>
            {

            };
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
            return new Budger
            {

            };
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
            return true;
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
            return new Budger
            {
            };
        }
    }
}
