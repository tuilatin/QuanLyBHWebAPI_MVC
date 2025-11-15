using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QUANLYBANHANG.Models; // Đảm bảo đúng namespace cho ApplicationUser
using QUANLYBANHANG.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QUANLYBANHANG.Controllers
{
    // Cần có các DTO (Data Transfer Objects) này trong thư mục Models/DTOs hoặc tương tự
    // public record RegisterModel(string Username, string Email, string Password);
    // public record LoginModel(string Username, string Password);

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager; // Đã đổi từ IdentityUser sang ApplicationUser
        private readonly RoleManager<IdentityRole> _roleManager; // <--- CẦN THÊM TRƯỜNG NÀY
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        // --- HÀM TẠO TOKEN (PRIVATE HELPER) ---
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            // Đọc Key từ appsettings.json
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT Key not configured.");
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3), // Token hết hạn sau 3 giờ
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        // --- API ĐĂNG KÝ USER ---
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // --- BƯỚC 1: KIỂM TRA USER TỒN TẠI ---
            var userExists = await _userManager.FindByNameAsync(model.Username!);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = "Error", Message = "User already exists!" });
            }

            // --- BƯỚC 2: TẠO ĐỐI TƯỢNG APPLICATION USER ---
            ApplicationUser user = new()
            {
                UserName = model.Username,
                // Gán Email mặc định (ảo) để thỏa mãn yêu cầu của database
                Email = model.Username + "@default.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // --- BƯỚC 3: TẠO USER VÀ HASH MẬT KHẨU ---
            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                // --- BƯỚC 4: GÁN ROLE MẶC ĐỊNH ("User") ---

                // 4.1. Đảm bảo Role "User" tồn tại (Phòng ngừa, nếu Seeder chưa chạy)
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    // TẠO Role "User" nếu nó chưa có
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                // 4.2. Gán Role "User" cho người dùng mới
                await _userManager.AddToRoleAsync(user, "User");

                return Ok(new { Status = "Success", Message = "User registered and assigned 'User' role successfully!" });
            }

            // --- BƯỚC 5: TRẢ VỀ LỖI NẾU TẠO USER THẤT BẠI ---
            return StatusCode(StatusCodes.Status500InternalServerError,
                new
                {
                    Status = "Error",
                    Message = "User creation failed!",
                    Errors = result.Errors.Select(e => e.Description)
                });
        }

        // --- API ĐĂNG NHẬP VÀ CẤP TOKEN ---
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username!);

            // 1. Kiểm tra User tồn tại và mật khẩu hợp lệ
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password!))
            {
                // 2. Lấy Roles và tạo Claims
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.NameIdentifier, user.Id), // ID User là cần thiết
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID
                };

                // Thêm Roles vào Claims
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                // 3. Tạo Token và trả về
                var token = CreateToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    username = user.UserName,
                    role = userRoles.FirstOrDefault()
                });
            }

            return Unauthorized(new { Status = "Error", Message = "Invalid Username or Password." });
        }
    }
}

// ⚠️ LƯU Ý QUAN TRỌNG: Bạn cần định nghĩa các DTO sau để code này hoạt động:
/*
public record RegisterModel(string Username, string Email, string Password);
public record LoginModel(string Username, string Password);
*/