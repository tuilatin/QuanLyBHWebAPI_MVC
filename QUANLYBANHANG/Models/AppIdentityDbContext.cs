using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QUANLYBANHANG.Models
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.HasDefaultSchema("AspNetIdentity");

            //// Tuỳ chỉnh tên bảng nếu muốn
            //builder.Entity<IdentityUser>(b => b.ToTable("Users"));
            //builder.Entity<IdentityRole>(b => b.ToTable("Roles"));
            //builder.Entity<IdentityUserRole<string>>(b => b.ToTable("UserRoles"));
            //builder.Entity<IdentityUserClaim<string>>(b => b.ToTable("UserClaims"));
            //builder.Entity<IdentityUserLogin<string>>(b => b.ToTable("UserLogins"));
            //builder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("RoleClaims"));
            //builder.Entity<IdentityUserToken<string>>(b => b.ToTable("UserTokens"));
        }
    }
}
