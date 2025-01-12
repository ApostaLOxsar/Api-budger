using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;


namespace Api_budger.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleController :ControllerBase
    {
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger) 
        {
            _logger = logger;
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
            return new List<Role>
            {
            };
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
            return new Role
            {
            };
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
            return new Role
            {
            };
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
            return true;
        }


        [HttpPut]
        [Route("CorrectRole")]
        [ProducesResponseType(200, Type = typeof(Role))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Role> CorrectRole(long Id, InputRole inputRole)
        {
            return new Role
            {
            };
        }
    }
}
