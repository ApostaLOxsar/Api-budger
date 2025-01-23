using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Api_budger.Models.output;

namespace Api_budger.Controllers
{
    [Route("Incom")]
    [ApiController]
    public class IncomController : ControllerBase
    {
        private readonly ILogger<IncomController> _logger;
        private readonly IBudgerService _budgerService;
        private readonly IMapper _mapper;
        public IncomController(ILogger<IncomController> logger, IBudgerService budgerService, IMapper mapper)
        {
            _logger = logger;
            _budgerService = budgerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetIncomByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputIncom>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputIncom>> GetIncomByFamilyId(long familyId)
        {
            var listIncoms = await _budgerService.GetIncomByFamilyIdAsyns(familyId);
            var resalt = _mapper.Map<IEnumerable<OutputIncom>>(listIncoms);
            return resalt;
        }

        [HttpGet]
        [Route("GetIncomByUser/{useryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputIncom>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputIncom>> GetIncomByUserId(long useryId)
        {
            var listIncoms = await _budgerService.GetIncomByUserIdAsyns(useryId);
            var resalt = _mapper.Map<IEnumerable<OutputIncom>>(listIncoms);
            return resalt;
        }

        [HttpPost]
        [Route("AddIncoms")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputIncom>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputIncom>> AddIncoms(IEnumerable<InputIncom> inputIncom)
        {
            var newIncom = await _budgerService.AddIncomsAsyns(inputIncom);
            var resalt = _mapper.Map<IEnumerable<OutputIncom>>(newIncom);
            return resalt;
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
        [ProducesResponseType(200, Type = typeof(OutputIncom))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputIncom> CorrectIncom(long Id, InputIncom inputIncom)
        {
            var correctIncom = await _budgerService.CorrectIncomAsyns(Id, inputIncom);
            var resalt = _mapper.Map<OutputIncom>(correctIncom);
            return resalt;
        }
    }
}
