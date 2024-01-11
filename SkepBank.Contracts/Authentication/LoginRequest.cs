namespace SkepBank.Contracts.Authentication
{
    public record LoginRequest(
        string userName,
        string password);
}
