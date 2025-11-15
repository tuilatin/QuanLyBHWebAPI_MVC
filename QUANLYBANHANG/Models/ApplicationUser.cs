using Microsoft.AspNetCore.Identity;

namespace QUANLYBANHANG.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Thêm các thuộc tính tùy chỉnh vào đây
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
