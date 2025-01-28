using Api_budger.Services.Abstractions;

namespace Api_budger.Infrastructure
{
    public class PasswordHasher : IPasswordHashService
    {
        public string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string passwordHash, string pasword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(pasword, passwordHash);
        }
    }
}
