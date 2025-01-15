using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;

namespace Api_budger.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IClientService _clientService;

        public UserController(ILogger<UserController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
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
            var listAllUsers = await _clientService.GetUsersAsync();
            return listAllUsers;
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
            var user = await _clientService.GetUserByIdAsync(id);
            return user;
        }

        [HttpPost]
        [Route("AddUser")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<User> AddUser(InputUser inputUser)
        {
            var newUser = await _clientService.AddUserAsyns(inputUser);
            return newUser;
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
            return await _clientService.DeleteUserByIdAsyns(id);
        }

        [HttpPut]
        [Route("CorrectUser")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<User> CorrectUser(long id, InputUser inputUser)
        {
            var correctUser = await _clientService.CorrectUserAsyns(id, inputUser);
            return correctUser;
        }
    }
}
