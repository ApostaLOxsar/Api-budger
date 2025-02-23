﻿using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.input;
using Api_budger.Models.output;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Controllers
{
    [Authorize(Policy = "userPolicy")]
    [Route("IncomCategory")]
    [ApiController]
    public class IncomCategoryController : ControllerBase
    {
        private readonly ILogger<IncomCategoryController> _logger;
        private readonly IBudgerService _budgerService;
        private readonly IMapper _mapper;
        public IncomCategoryController(ILogger<IncomCategoryController> logger, IBudgerService budgerService, IMapper mapper)
        {
            _logger = logger;
            _budgerService = budgerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetIncomCategoryByFamily")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputIncomCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputIncomCategory>> GetIncomCategoryByFamilyId()
        {
            var incomCategories = await _budgerService.GetIncomCategoryByFamilyIdAsyns();
            var resalt = _mapper.Map<IEnumerable<OutputIncomCategory>>(incomCategories);
            return resalt;
        }

        [HttpPost]
        [Route("AddIncomCategoryInFamily")]
        [ProducesResponseType(200, Type = typeof(OutputIncomCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputIncomCategory>> AddIncomCategoryInFamily(IEnumerable<InputIncomCategory> inputIncomCategory)
        {
            var newIncomCategory = await _budgerService.AddIncomCategoryInFamilyAsyns(inputIncomCategory);
            var resalt = _mapper.Map<IEnumerable<OutputIncomCategory>>(newIncomCategory);
            return resalt;
        }

        [HttpDelete]
        [Route("DeleteIncomCategoryFromFamily/{incomCategoryId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteIncomCategoryFromFamilyById(long incomCategoryId)
        {
            return await _budgerService.DeleteIncomCategoryFromFamilyByIdAsyns(incomCategoryId);
        }

        [HttpPut]
        [Route("CorrectIncomCategoryFromUser/{id}")]
        [ProducesResponseType(200, Type = typeof(OutputIncomCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputIncomCategory> CorrectIncomCategoryFromUserById(long id, InputIncomCategory inputIncomCategory)
        {
            var correctIncomCategory = await _budgerService.CorrectIncomCategoryFromUserByIdAsyns(id, inputIncomCategory);
            var resalt = _mapper.Map<OutputIncomCategory>(correctIncomCategory);
            return resalt;
        }
    }
}
