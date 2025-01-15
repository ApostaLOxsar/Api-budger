using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;

namespace Api_budger.Controllers
{

    [Route("Family")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly ILogger<FamilyController> _logger;
        private readonly IClientService _clientService;
        public FamilyController(ILogger<FamilyController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
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
            var listFamily = await _clientService.GetFamiliesAsync();
            return listFamily;
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
            var family = await _clientService.GetFamilyByIdAsync(id);
            return family;
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
            var newFamily = await _clientService.AddFamilyAsyns(family);
            return newFamily;
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
            return await _clientService.DeleteFamilyByIdAsyns(id);
        }

        [HttpPut]
        [Route("CorrectFamily/{id}")]
        [ProducesResponseType(200, Type = typeof(Family))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Family> CorrectFamily(long id, InputFamily inputFamily)
        {
            var correctFamily = await _clientService.CorrectFamilyAsyns(id, inputFamily);
            return correctFamily;
        }
    }
}
