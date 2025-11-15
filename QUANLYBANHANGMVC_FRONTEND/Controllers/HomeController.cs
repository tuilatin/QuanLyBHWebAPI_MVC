using Microsoft.AspNetCore.Mvc;
using QUANLYBANHANGMVC_FRONTEND.Models;
using QUANLYBANHANGMVC_FRONTEND.Models.ViewModels;
using System.Diagnostics;

namespace QUANLYBANHANGMVC_FRONTEND.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("BackendApi");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Sanpham");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<SanPhamViewModel>>();
                return View(products);
            }

            // Nếu lỗi, trả về view với danh sách rỗng hoặc xử lý lỗi
            return View(new List<SanPhamViewModel>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Sanpham/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<SanPhamViewModel>();
                return View("~/Views/Home/Details.cshtml", product);
            }

            TempData["Error"] = "Không tìm thấy sản phẩm.";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
