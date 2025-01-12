using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;

namespace Api_budger.Controllers
{
    [Route("Incom")]
    [ApiController]
    public class IncomComtroller : ControllerBase
    {
        private readonly ILogger<IncomComtroller> _logger;
        public IncomComtroller(ILogger<IncomComtroller> logger)
        {
            _logger = logger;
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
            return new List<Incom>
            {
            };
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
            return new List<Incom>
            {

            };
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
            return new Incom
            {

            };
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
            return true;
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
            return new Incom
            {
            };
        }
    }
}
