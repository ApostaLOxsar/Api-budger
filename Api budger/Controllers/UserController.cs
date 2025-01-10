using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;

namespace Api_budger.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationContext _context;

        public UserController(ILogger<UserController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return new List<User>
            { 
            };
        }

        [HttpPost]
        [Route("AddUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InputUser>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<User>> AddUsers(IEnumerable<InputUser> users)
        {
            return new List<User>
            {
            };
        }

        [HttpGet]
        [Route("GetUser{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<User> GetUser(long id)
        {
            return new User
            {
            };
        }

        [HttpPost]
        [Route("AddUser")]
        [ProducesResponseType(200, Type = typeof(InputUser))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<User> AddUser(InputUser User)
        {
            return new User
            {
            };
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteUser(long id)
        {
            return true;
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

        [HttpPost]
        [Route("AddRoles")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InputRole>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Role>> AddRoles(IEnumerable<InputRole> roles)
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
        [ProducesResponseType(200, Type = typeof(InputRole))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<Role> AddRole(InputRole role)
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

        [HttpPost]
        [Route("AddFamilies")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InputFamily>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<Family>> AddFamilies(IEnumerable<InputFamily> families)
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
        public async Task<Family> GetFamily(long id)
        {
            return new Family
            {
            };
        }

        [HttpPost]
        [Route("AddFamily")]
        [ProducesResponseType(200, Type = typeof(InputFamily))]
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
        public async Task<bool> DeleteFamily(long id)
        {
            return true;
        }
    }
}
