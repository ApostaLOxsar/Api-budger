using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<BudgerController> _logger;
        private readonly IBudgerService _budgerService;
        private readonly IMapper _mapper;
        private readonly ICurentUserService _curentUserService;
        private readonly IClientService _clientService;
        public TestController(ILogger<BudgerController> logger,
                              IBudgerService budgerService,
                              IMapper mapper,
                              ICurentUserService curentUserService,
                              IClientService clientService)
        {
            _logger = logger;
            _budgerService = budgerService;
            _mapper = mapper;
            _curentUserService = curentUserService;
            _clientService = clientService;
        }

        [HttpGet]
        [Route("Test")]
        //[Authorize(Policy = "userPolicy")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<long>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public Task Test(long id)
        {
            return Task.CompletedTask;
        }
    }
}
