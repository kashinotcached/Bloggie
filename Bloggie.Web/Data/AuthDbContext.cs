using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var superAdminRoleId = "ac3242df-dec7-43dd-bdd8-7dff593884e4";
        var adminRoleId = "5fd5a956-c5f4-439e-8fcd-ba589459e1b5";
        var userRoleId = "335eb0fb-1110-4be4-8c6c-8cfb1c89462b";

        // Seed Roles (User, Admin, Super Admin)
        var roles = new List<IdentityRole>
        {
            new IdentityRole()
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = superAdminRoleId,
                ConcurrencyStamp = superAdminRoleId
            },
            new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "User",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);

        // Seed Super Admin User
        var superAdminId = "cd24c75f-f7d2-4212-9334-25e0f9f40e42";
        var superAdminUser = new IdentityUser()
        {
            Id = superAdminId,
            UserName = "superadmin@bloggie.com",
            Email = "superadmin@bloggie.com"
        };

        superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(superAdminUser, "superadmin123");

        builder.Entity<IdentityUser>().HasData(superAdminUser);

        //Add All Roles To Super Admin User
        var superAdminRoles = new List<IdentityUserRole<string>>()
        {
            new IdentityUserRole<string>
            {
                RoleId = superAdminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId= superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId= superAdminId
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
    }
}
