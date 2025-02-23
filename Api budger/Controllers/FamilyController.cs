﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;
using Api_budger.Models.output;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Api_budger.Controllers
{
    [Authorize]
    [Route("Family")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly ILogger<FamilyController> _logger;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public FamilyController(ILogger<FamilyController> logger, IClientService clientService, IMapper mapper)
        {
            _logger = logger;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "adminPolicy")]
        [Route("GetFamilies")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputFamily>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputFamily>> GetFamilies()
        {
            var listFamily = await _clientService.GetFamiliesAsync();
            var result = _mapper.Map<IEnumerable<OutputFamily>>(listFamily);
            return result;
        }

        [HttpGet]
        [Authorize(Policy = "adminPolicy")]
        [Route("GetFamily/{id}")]
        [ProducesResponseType(200, Type = typeof(OutputFamily))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputFamily> GetFamilyById(long id)
        {
            var family = await _clientService.GetFamilyByIdAsync(id);
            var result = _mapper.Map<OutputFamily>(family);
            return result;
        }

        [HttpGet]
        [Authorize(Policy = "userPolicy")]
        [Route("GetFamilyByUser/{id}")]
        [ProducesResponseType(200, Type = typeof(OutputFamily))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputFamily> GetFamilyByUserId(long id)
        {
            var family = await _clientService.GetFamilyByUserIdAsync(id);
            var result = _mapper.Map<OutputFamily>(family);
            return result;
        }

        [HttpPost]
        [Authorize(Policy = "moderationPolicy")]
        [Route("AddFamily")]
        [ProducesResponseType(200, Type = typeof(OutputFamily))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputFamily> AddFamily(InputFamily family)
        {
            var newFamily = await _clientService.AddFamilyAsyns(family);
            var result = _mapper.Map<OutputFamily>(newFamily);
            return result;
        }

        [HttpDelete]
        [Authorize(Policy = "userPolicy")]
        [Route("DeleteFamily/{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteFamilyById(long id)
        {
            return await _clientService.DeleteFamilyByIdAsyns(id);
        }

        [HttpPut]
        [Authorize(Policy = "userPolicy")]
        [Route("CorrectFamily/{id}")]
        [ProducesResponseType(200, Type = typeof(OutputFamily))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputFamily> CorrectFamily(long id, InputFamily inputFamily)
        {
            var correctFamily = await _clientService.CorrectFamilyAsyns(inputFamily);
            var result = _mapper.Map<OutputFamily>(correctFamily);
            return result;
        }
    }
}
