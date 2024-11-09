namespace Infrastructure.Configurations
{
    public class JwtOptions
    {
        public const string SectionsName = "JwtSettings";
        public required string SecretKey { get; init; }
        public int ExpiryMinutes { get; init; } = 30;
        public required string Issuer { get; init; }
        public required string Audience { get; init; }
    }
}
