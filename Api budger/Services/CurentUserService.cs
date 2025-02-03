using System.Security.Claims;
using Api_budger.Consts;
using Api_budger.Models.Abstractions;
using Api_budger.Models.clients;
using Api_budger.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api_budger.Services
{
    public class CurentUserService : ICurentUserService
    {
        private readonly IHttpContextAccessor _context;
        public CurentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }

        public long GetUserId()
        {
            try
            {
                var identities = _context.HttpContext.User.Identity as ClaimsIdentity;
                var userId = long.Parse(identities.FindFirst("userId").Value);
                return userId;
            }
            catch
            {
                _context.HttpContext.Response.Cookies.Delete("litle_baby");
                throw new Exception("autentification incorrect");
            }
        }

        public RoleConst GetUserRole()
        {
            try
            {
                var identities = _context.HttpContext.User.Identity as ClaimsIdentity;
                var claimValue = identities.FindFirst("roleId").Value;
                int roleId = int.Parse(claimValue);
                var role = (RoleConst)Enum.ToObject(typeof(RoleConst), roleId);
                return role;
            }
            catch
            {
                _context.HttpContext.Response.Cookies.Delete("litle_baby");
                throw new Exception("autentification incorrect");
            }
        }
    }
}
