using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;
using Api_budger.Services.Abstractions;

namespace Api_budger.Controllers
{
    [Route("Incom")]
    [ApiController]
    public class IncomController : ControllerBase
    {
        private readonly ILogger<IncomController> _logger;
        private readonly IBudgerService _budgerService;
        public IncomController(ILogger<IncomController> logger, IBudgerService budgerService)
        {
            _logger = logger;
            _budgerService = budgerService;
        }

        [HttpGet]
        [Route("GetIncomByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Incom>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Incom>> GetIncomByFamilyId(long familyId)
        {
            var listIncoms = await _budgerService.GetIncomByFamilyIdAsyns(familyId);
            return listIncoms;
        }

        [HttpGet]
        [Route("GetIncomByUser/{useryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Incom>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Incom>> GetIncomByUserId(long useryId)
        {
            var listIncoms = await _budgerService.GetIncomByUserIdAsyns(useryId);
            return listIncoms;
        }

        [HttpPost]
        [Route("AddIncom")]
        [ProducesResponseType(200, Type = typeof(Incom))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Incom> AddIncom(InputIncom inputIncom)
        {
            var newIncom = await _budgerService.AddIncomAsyns(inputIncom);
            return newIncom;
        }

        [HttpDelete]
        [Route("DeleteIncom/{incomId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteIncomById(long incomId)
        {
            return await _budgerService.DeleteIncomByIdAsyns(incomId);
        }

        [HttpPut]
        [Route("CorrectIncom")]
        [ProducesResponseType(200, Type = typeof(Incom))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Incom> CorrectIncom(long Id, InputIncom inputIncom)
        {
            var correctIncom = await _budgerService.CorrectIncomAsyns(Id, inputIncom);
            return correctIncom;
        }
    }
}
