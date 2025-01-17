using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;
using Api_budger.Models.output;
using AutoMapper;


namespace Api_budger.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleController :ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public RoleController(ILogger<RoleController> logger, IClientService clientService, IMapper mapper) 
        {
            _logger = logger;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetRoles")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputRole>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputRole>> GetRoles()
        {
            var listAllRoles = await _clientService.GetRolesAsync();
            var result = _mapper.Map<IEnumerable<OutputRole>>(listAllRoles);
            return result;
        }

        [HttpGet]
        [Route("GetRole/{id}")]
        [ProducesResponseType(200, Type = typeof(OutputRole))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputRole> GetRole(long id)
        {
            var listRole = await _clientService.GetRoleByIdAsync(id);
            var result = _mapper.Map<OutputRole>(listRole);
            return result;
        }

        [HttpPost]
        [Route("AddRole")]
        [ProducesResponseType(200, Type = typeof(OutputRole))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputRole> AddRole(InputRole inputRole)
        {
            var newRole = await _clientService.AddRoleAsyns(inputRole);
            var result = _mapper.Map<OutputRole>(newRole);
            return result;
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteRole(long id)
        {
            return await _clientService.DeleteRoleByIdAsyns(id);
        }


        [HttpPut]
        [Route("CorrectRole")]
        [ProducesResponseType(200, Type = typeof(OutputRole))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputRole> CorrectRole(long id, InputRole inputRole)
        {
            var correctRole = await _clientService.CorrectRoleAsyns(id, inputRole);
            var result = _mapper.Map<OutputRole>(correctRole);
            return result;
        }
    }
}
