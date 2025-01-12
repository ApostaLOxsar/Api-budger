using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
{
    [Route("IncomCategory")]
    [ApiController]
    public class IncomCategoryController : ControllerBase
    {
        private readonly ILogger<IncomCategoryController> _logger;
        public IncomCategoryController(ILogger<IncomCategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetIncomCategoryByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IncomCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<IncomCategory>> GetIncomByFamilyId(long familyId)
        {
            return new List<IncomCategory>
            {
            };
        }

        [HttpPost]
        [Route("AddIncomCategory")]
        [ProducesResponseType(200, Type = typeof(IncomCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IncomCategory> AddIncom(InputIncomCategory inputIncomCategory)
        {
            return new IncomCategory
            {

            };
        }

        [HttpDelete]
        [Route("DeleteIncomCategory/{incomCategoryId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteIncomById(long incomCategoryId)
        {
            return true;
        }

        [HttpPut]
        [Route("CorrectIncomCategory")]
        [ProducesResponseType(200, Type = typeof(IncomCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IncomCategory> CorrectIncom(long Id, InputIncomCategory inputIncomCategory)
        {
            return new IncomCategory
            {
            };
        }
    }
}
