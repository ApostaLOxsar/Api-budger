using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
{
    [Route("Authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public AuthorizationController(IClientService clientService, IMapper mapper)
        { 
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<string> Login([FromQuery] LoginInput loginInput)
        {
            var result = await _clientService.Login(loginInput);
            return result;
        }

        [HttpGet]
        [Route("Logout")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> Logout()
        {
            return true;
        }

        [HttpPost]
        [Route("Registration")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputUser> AddUser(InputUser inputUser)
        {
            var newUser = await _clientService.AddUserAsyns(inputUser);
            var result = _mapper.Map<OutputUser>(newUser);
            return result;
        }
    }
}
