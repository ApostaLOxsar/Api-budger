﻿using System.Collections.Generic;
using Api_budger.Models.clients;
using Api_budger.Models.input;
using Api_budger.Repositories.Abstractions;
using Api_budger.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;

namespace Api_budger.Services
{
    public class ClientService : IClientService
    {
        private readonly ILogger<ClientService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IBudgerRepository _budgerRepository;
        private readonly IMapper _mapper;
        public ClientService(ILogger<ClientService> logger, IUserRepository userRepository, IBudgerRepository budgerRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _budgerRepository = budgerRepository;
            _mapper = mapper;
        }
        public async Task<Family> AddFamilyAsyns(InputFamily inputFamily)
        {
            var famili = _mapper.Map<Family>(inputFamily);
            return await _userRepository.AddFamilyAsyns(famili);
        }

        public async Task<Role> AddRoleAsyns(InputRole inputRole)
        {
            var role = _mapper.Map<Role>(inputRole);
            return await _userRepository.AddRoleAsyns(role);
        }

        public async Task<User> AddUserAsyns(InputUser inputUser)
        {
            var user = _mapper.Map<User>(inputUser);
            return await _userRepository.AddUserAsyns(user);
        }

        public async Task<Family> CorrectFamilyAsyns(long id, InputFamily inputFamily)
        {
            var famili = _mapper.Map<Family>(inputFamily);
            return await _userRepository.CorrectFamilyByIdAsyns(id, famili);
        }

        public async Task<Role> CorrectRoleAsyns(long id, InputRole inputRole)
        {
            var role = _mapper.Map<Role>(inputRole);
            return await _userRepository.CorrectRoleByIdAsyns(id, role);
        }

        public async Task<User> CorrectUserAsyns(long id, InputUser inputUser)
        {
            var user = _mapper.Map<User>(inputUser);
            return await _userRepository.CorrectUserByIdAsyns(id, user);
        }

        public async Task<bool> DeleteFamilyByIdAsyns(long id)
        {
            return await _userRepository.DeleteFamilyByIdAsyns(id);
        }

        public async Task<bool> DeleteRoleByIdAsyns(long id)
        {
            return await _userRepository.DeleteRoleByIdAsyns(id);
        }

        public async Task<bool> DeleteUserByIdAsyns(long id)
        {
            return await _userRepository.DeleteUserByIdAsync(id);
        }

        public async Task<ICollection<Family>> GetFamiliesAsync()
        {
            var families = await _userRepository.GetAllFamilyAsync();
            if (families is null) throw new Exception("Users not found");
            return families;
        }

        public async Task<Family> GetFamilyByIdAsync(long id)
        {
            var family = await _userRepository.GetFamilyByIdAsync(id);
            if (family is null) throw new Exception("Family not found");
            return family;
        }

        public async Task<Family> GetFamilyByUserIdAsync(long id)
        {
            var family = await _userRepository.GetFamilyByUserIdAsync(id);
            if (family is null) throw new Exception("Family not found");
            return family;
        }

        public async Task<Role> GetRoleByIdAsync(long id)
        {
            var role = await _userRepository.GetRoleByIdAsync(id);
            if (role is null) throw new Exception("Role not found");
            return role;
        }

        public async Task<ICollection<Role>> GetRolesAsync()
        {
            var roles = await _userRepository.GetAllRoleAsync();
            if (roles is null) throw new Exception("Not founs role");
            return roles;
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user is null) throw new Exception("Not founs role");
            return user;
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            var user = await _userRepository.GetAllUsersAsync();
            if (user is null) throw new Exception("Users not found");
            return user;
        }
    }
}
