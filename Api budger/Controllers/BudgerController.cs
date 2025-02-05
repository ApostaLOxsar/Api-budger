using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Models.budgers;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Api_budger.Models.output;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Api_budger.Controllers
{
    [Authorize]
    [Route("Budger")]
    [ApiController]
    public class BudgerController : ControllerBase
    {
        private readonly ILogger<BudgerController> _logger;
        private readonly IBudgerService _budgerService;
        private readonly IMapper _mapper;
        public BudgerController(ILogger<BudgerController> logger, IBudgerService budgerService, IMapper mapper)
        {
            _logger = logger;
            _budgerService = budgerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "userPolicy")]
        [Route("GetBudgerByFamily/{familyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputBudger>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputBudger>> GetBudgerByFamilyId()
        {
            var listBudger = await _budgerService.GetBudgerByFamilyIdAsyns();
            var resalt = _mapper.Map<IEnumerable<OutputBudger>>(listBudger);
            return resalt;
        }

        [HttpGet]
        [Authorize(Policy = "userPolicy")]
        [Route("GetBudgerByUser/{useryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputBudger>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputBudger>> GetBudgerByUserId()
        {
            var budger = await _budgerService.GetBudgerByUserIdAsyns();
            var resalt = _mapper.Map<IEnumerable<OutputBudger>>(budger);
            return resalt;
        }

        [HttpPost]
        [Route("AddBudger")]
        [ProducesResponseType(200, Type = typeof(OutputBudger))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputBudger>> AddBudger(IEnumerable<InputBudger> inputBudger)
        {
            var newBudger = await _budgerService.AddBudgersAsyns(inputBudger);
            var resalt = _mapper.Map<IEnumerable<OutputBudger>>(newBudger);
            return resalt;
        }

        [HttpDelete]
        [Route("DeleteBudger/{budgerId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<bool> DeleteBudgerById(long budgerId)
        {
            //проверить работособность выборки из бд
            return await _budgerService.DeleteBudgerByIdAsyns(budgerId);
        }

        [HttpPut]
        [Route("CorrectBudger")]
        [ProducesResponseType(200, Type = typeof(Budger))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputBudger> CorrectBudger(long Id, InputBudger inputBudger)
        {
            var budger = await _budgerService.CorrectBudgerAsyns(Id, inputBudger);
            var resalt = _mapper.Map<OutputBudger>(budger);
            return resalt;
        }
    }
}
