﻿using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Api_budger.Models.output;
using Microsoft.AspNetCore.Authorization;

namespace Api_budger.Controllers
{
    [Authorize(Policy = "userPolicy")]
    [Route("BudgerCategory")]
    [ApiController]
    public class BudgerCategoryController : ControllerBase
    {
        private readonly ILogger<BudgerCategoryController> _logger;
        private readonly IBudgerService _budgerService;
        private readonly IMapper _mapper;
        public BudgerCategoryController(ILogger<BudgerCategoryController> logger, IBudgerService budgerService, IMapper mapper)
        {
            _logger = logger;
            _budgerService = budgerService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetBudgerCategoryByFamily")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputBudgerCategory>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputBudgerCategory>> GetBudgerCategoryByFamilyId()
        {
            var budgerCategories = await _budgerService.GetBudgerCategoryByFamilyIdAsyns();
            var resalt = _mapper.Map<IEnumerable<OutputBudgerCategory>>(budgerCategories);
            return resalt;
        }

        [HttpPost]
        [Route("AddBudgerCategoryInFamily")]
        [ProducesResponseType(200, Type = typeof(OutputBudgerCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputBudgerCategory>> AddBudgerCategoryInFamily(IEnumerable<InputBudgerCategory> inputBudger)
        {
            var budgerCategory = await _budgerService.AddBudgerCategoryInFamilyAsyns(inputBudger);
            var resalt = _mapper.Map<IEnumerable<OutputBudgerCategory>>(budgerCategory);
            return resalt;
        }

        [HttpDelete]
        [Route("DeleteBudgerCategoryFromFamily/{budgerCategoryId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteBudgerCategoryFromFamilyById(long budgerCategoryId)
        {
            return await _budgerService.DeleteBudgerCategoryFromFamilyByIdAsyns(budgerCategoryId);
        }

        [HttpPut]
        [Route("CorrectBudgerCategoryFromUser/{id}")]
        [ProducesResponseType(200, Type = typeof(OutputBudgerCategory))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputBudgerCategory> CorrectBudgerCategoryFromUserById(long id, InputBudgerCategory inputBudgerCategory)
        {
            var budgerCategory = await _budgerService.CorrectBudgerCategoryFromUserByIdAsyns(id, inputBudgerCategory);
            var resalt = _mapper.Map<OutputBudgerCategory>(budgerCategory);
            return resalt;
        }
    }
}
