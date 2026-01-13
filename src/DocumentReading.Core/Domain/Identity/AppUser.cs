using Microsoft.AspNetCore.Identity;

namespace DocumentReading.Core.Domain.Identity
{
    internal class AppUser : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool isActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Dob { get; set; }
        public string? Avatar { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
