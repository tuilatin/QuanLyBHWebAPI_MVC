using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QUANLYBANHANGMVC_FRONTEND.Attributes
{
    /// <summary>
    /// Attribute để kiểm tra chỉ Admin mới được truy cập
    /// Kiểm tra role từ Session
    /// </summary>
    public class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetString("UserRole");

            // Kiểm tra nếu không có role hoặc role không phải Admin
            if (string.IsNullOrEmpty(role) || role != "Admin")
            {
                // Chuyển hướng về trang đăng nhập hoặc trang chủ
                context.Result = new RedirectToActionResult("Login", "Account", null);
                
                // Hoặc có thể trả về Unauthorized
                // context.Result = new UnauthorizedResult();
                
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}

