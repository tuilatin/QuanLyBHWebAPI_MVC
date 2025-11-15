using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using QUANLYBANHANG.Models; // Sử dụng ApplicationUser của bạn
using System.Threading.Tasks;

public static class SeedData
{
    private static readonly string[] Roles = new[] { "Admin", "User" };

    // Thông tin tài khoản mặc định
    private const string AdminUsername = "admin";
    private const string AdminPassword = "admin";
    private const string BasicUsername = "user";
    private const string BasicPassword = "user";


    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            // 🚨 THAY ĐỔI QUAN TRỌNG: Lấy DbContext Identity TRỰC TIẾP
            var context = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            // (TÙY CHỌN) Đảm bảo Database đã được tạo hoặc Migration đã chạy
            // await context.Database.MigrateAsync(); 

            // Lấy RoleManager và UserManager TỪ SERVICE PROVIDER (nhưng nó sẽ biết dùng context nào)
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // A. TẠO ROLES CÓ SẴN
            await SeedRolesAsync(roleManager);

            // B. TẠO VÀ GÁN ROLE CHO USER MẶC ĐỊNH
            await SeedUsersAsync(userManager);
        }
    }


    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
    {
        // 1. TẠO ADMIN MẶC ĐỊNH
        var adminUser = await userManager.FindByNameAsync(AdminUsername);
        if (adminUser == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = AdminUsername,
                Email = AdminUsername + "@default.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(newAdmin, AdminPassword);

            if (result.Succeeded)
            {
                // Gán Role Admin cho tài khoản Admin
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }

        // 2. TẠO USER MẶC ĐỊNH
        var basicUser = await userManager.FindByNameAsync(BasicUsername);
        if (basicUser == null)
        {
            var newUser = new ApplicationUser
            {
                UserName = BasicUsername,
                Email = BasicUsername + "@default.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(newUser, BasicPassword);

            if (result.Succeeded)
            {
                // Gán Role User cho tài khoản User
                await userManager.AddToRoleAsync(newUser, "User");
            }
        }
    }
}