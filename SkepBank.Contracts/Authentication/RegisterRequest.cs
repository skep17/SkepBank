namespace SkepBank.Contracts.Authentication
{
    public record RegisterRequest(
        string userName,
        string password);
}
