using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;

namespace Api_budger.Controllers
{

    [Route("Family")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly ILogger<FamilyController> _logger;
        public FamilyController(ILogger<FamilyController> logger) 
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetFamilies")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Family>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Family>> GetFamilies()
        {
            return new List<Family>
            {
            };
        }

        [HttpGet]
        [Route("GetFamily{id}")]
        [ProducesResponseType(200, Type = typeof(Family))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Family> GetFamilyById(long id)
        {
            return new Family
            {
            };
        }

        [HttpPost]
        [Route("AddFamily")]
        [ProducesResponseType(200, Type = typeof(Family))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Family> AddFamily(InputFamily family)
        {
            return new Family
            {
            };
        }

        [HttpDelete]
        [Route("DeleteFamily/{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteFamilyById(long id)
        {
            return true;
        }

        [HttpPut]
        [Route("CorrectFamily")]
        [ProducesResponseType(200, Type = typeof(Family))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Family> CorrectFamily(long Id, InputFamily inputFamily)
        {
            return new Family
            {
            };
        }
    }
}
