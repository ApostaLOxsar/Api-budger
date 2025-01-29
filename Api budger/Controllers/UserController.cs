﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Api_budger.Infrastructure.Interface;
using System.ComponentModel.DataAnnotations;

namespace Api_budger.Controllers
{
    [Route("User")]
    [ApiController]
    [Authorize(Policy = "adminPolicy")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        private readonly IJwtProvider _jwtProvider;

        public UserController(ILogger<UserController> logger,
                              IClientService clientService,
                              IMapper mapper,
                              IHttpContextAccessor context,
                              IJwtProvider jwtProvider)
        {
            _logger = logger;
            _clientService = clientService;
            _mapper = mapper;
            _context = context;
            _jwtProvider = jwtProvider;
        }

        [HttpGet]
        [Route("GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutputUser>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<OutputUser>> GetUsers()
        {
            var listAllUsers = await _clientService.GetUsersAsync();
            var result = _mapper.Map<IEnumerable<OutputUser>>(listAllUsers);
            return result;
        }

        [HttpGet]
        [Route("Test")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public string Test()
        {
            var test = _context.HttpContext.Request.Cookies["litle_baby"];
           // _jwtProvider.
            return test;
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<OutputUser> GetUser(long id)
        {
            var user = await _clientService.GetUserByIdAsync(id);
            var result = _mapper.Map<OutputUser>(user);
            return result;
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
        public async Task<OutputUser> CorrectUser(long id, InputUser inputUser)
        {
            var correctUser = await _clientService.CorrectUserAsyns(id, inputUser);
            var result = _mapper.Map<OutputUser>(correctUser);
            return result;
        }
    }
}
