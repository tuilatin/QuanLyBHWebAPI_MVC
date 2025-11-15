using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using QUANLYBANHANGMVC_FRONTEND.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using QUANLYBANHANGMVC_FRONTEND.Attributes;

namespace QUANLYBANHANGMVC_FRONTEND.Controllers
{
    [AdminOnly] // Áp dụng cho toàn bộ controller - chỉ Admin mới truy cập được
    public class SanphamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SanphamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient("BackendApi");
        }

        // ✅ GET: Sanpham
        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Sanpham");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<SanPhamViewModel>>();
                return View("~/Views/Admin/Sanpham/Index.cshtml", products);
            }

            TempData["Error"] = "Không thể tải danh sách sản phẩm. Vui lòng kiểm tra API backend.";
            return RedirectToAction("Error", "Home");
        }

        // ✅ GET: Sanpham/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Sanpham/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<SanPhamViewModel>();
                return View("~/Views/Admin/Sanpham/Details.cshtml", product);
            }

            TempData["Error"] = "Không tìm thấy sản phẩm.";
            return RedirectToAction(nameof(Index));
        }

        // ✅ GET: Sanpham/Create
        public async Task<IActionResult> Create()
        {
            await LoadDanhMucAsync();
            return View("~/Views/Admin/Sanpham/Create.cshtml");
        }

        // ✅ POST: Sanpham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPhamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDanhMucAsync(model.Madanhmuc);
                return View("~/Views/Admin/Sanpham/Create.cshtml", model);
            }

            var client = CreateClient();
            var response = await client.PostAsJsonAsync("Sanpham", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Lỗi khi thêm sản phẩm.";
            await LoadDanhMucAsync();
            return View("~/Views/Admin/Sanpham/Create.cshtml", model);
        }

        // ✅ GET: Sanpham/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Sanpham/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<SanPhamViewModel>();
                await LoadDanhMucAsync(product.Madanhmuc); // ← THÊM DÒNG NÀY
                return View("~/Views/Admin/Sanpham/Edit.cshtml", product);
            }

            TempData["Error"] = "Không tìm thấy sản phẩm.";
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDanhMucAsync(int? selectedValue = null)
        {
            var client = CreateClient();
            var response = await client.GetAsync("Danhmuc");

            if (response.IsSuccessStatusCode)
            {
                var danhMucList = await response.Content.ReadFromJsonAsync<List<DanhMucViewModel>>();
                ViewBag.Madanhmuc = new SelectList(danhMucList ?? new List<DanhMucViewModel>(),
                                                   "Madanhmuc",
                                                   "Madanhmuc",
                                                   selectedValue);
            }
            else
            {
                ViewBag.Madanhmuc = new SelectList(new List<DanhMucViewModel>(), "Madanhmuc", "Madanhmuc", selectedValue);
            }
        }

        // ✅ POST: Sanpham/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, SanPhamViewModel model)
        {
            if (id != model.Masanpham)
            {
                ModelState.AddModelError("", "ID sản phẩm không khớp.");
                await LoadDanhMucAsync(model.Madanhmuc);
                return View("~/Views/Admin/Sanpham/Edit.cshtml", model);
            }

            if (!ModelState.IsValid)
            {
                await LoadDanhMucAsync(model.Madanhmuc);
                return View("~/Views/Admin/Sanpham/Edit.cshtml", model);
            }

            var client = CreateClient();
            var response = await client.PutAsJsonAsync($"Sanpham/{id}", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Lỗi khi cập nhật sản phẩm.";
            await LoadDanhMucAsync(model.Madanhmuc);
            return View("~/Views/Admin/Sanpham/Edit.cshtml", model);
        }

        // ✅ GET: Sanpham/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Sanpham/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<SanPhamViewModel>();
                return View("~/Views/Admin/Sanpham/Delete.cshtml", product);
            }

            TempData["Error"] = "Không tìm thấy sản phẩm.";
            return RedirectToAction(nameof(Index));
        }

        // ✅ POST: Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = CreateClient();
            var response = await client.DeleteAsync($"Sanpham/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Xóa sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Không thể xóa sản phẩm.";
            return RedirectToAction(nameof(Index));
        }
    }
}
