namespace SkepBank.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid id,
        string userName,
        string token);
}
