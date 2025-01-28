using Api_budger.Models.clients;

namespace Api_budger.Infrastructure.Interface
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
