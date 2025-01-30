using Api_budger.Consts;
using Api_budger.Models.clients;

namespace Api_budger.Services.Abstractions
{
    public interface ICurentUserService
    {
        public long GetUserId();
        public RoleConst GetUserRole();
    }
}
