using DocumentReading.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DocumentReading.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(AppDbContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole
                {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Administrator"
                });
                await context.SaveChangesAsync();
            }
            if (!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser
                {
                    Id = userId,
                    UserName = "",
                    NormalizedUserName = "",
                    Email = "",
                    NormalizedEmail = "",
                    FirstName = "System",
                    LastName = "Administrator",
                    isActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.UtcNow,
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
