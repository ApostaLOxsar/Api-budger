using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;


namespace Api_budger.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleController :ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IClientService _clientService;

        public RoleController(ILogger<RoleController> logger, IClientService clientService) 
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet]
        [Route("GetRoles")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Role>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var listAllRoles = await _clientService.GetRolesAsync();
            return listAllRoles;
        }

        [HttpGet]
        [Route("GetRole{id}")]
        [ProducesResponseType(200, Type = typeof(Role))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Role> GetRole(long id)
        {
            var listRole = await _clientService.GetRoleByIdAsync(id);
            return listRole;
        }

        [HttpPost]
        [Route("AddRole")]
        [ProducesResponseType(200, Type = typeof(Role))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Role> AddRole(InputRole inputRole)
        {
            var newRole = await _clientService.AddRoleAsyns(inputRole);
            return newRole;
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
        [ProducesResponseType(200, Type = typeof(Role))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Role> CorrectRole(long id, InputRole inputRole)
        {
            var correctRole = await _clientService.CorrectRoleAsyns(id, inputRole);
            return correctRole;
        }
    }
}
