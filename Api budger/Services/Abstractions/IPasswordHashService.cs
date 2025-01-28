namespace Api_budger.Services.Abstractions
{
    public interface IPasswordHashService
    {
        public string GenerateHash(string password);
        public bool Verify(string passwordHash, string pasword);
    }
}
