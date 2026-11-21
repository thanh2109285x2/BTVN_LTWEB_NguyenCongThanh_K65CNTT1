using Microsoft.AspNetCore.Mvc;
using NguyenCongThanh_241230844_De2026_QLTS_DE2.Models;
using System.Diagnostics;

namespace NguyenCongThanh_241230844_De2026_QLTS_DE2.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _ct;
        public HomeController(QltaiSanContext ct)
        {
            _ct = ct;
        }
        public IActionResult Index()
        {
            ViewBag.TieuDe = "NguyenCongThanh";
            var ds = _ct.TaiSans.Where(ts => ts.NguyenGia >= 20).ToList();
            return View(ds);
        }

        public IActionResult TimKiem(int maloai)
        {
            ViewBag.TieuDe = _ct.LoaiTaiSans.FirstOrDefault(ts => ts.MaLoai == maloai)?.TenLoai;
            var ds = _ct.TaiSans.Where(ts => ts.MaLoai == maloai).ToList();
            return PartialView("NguyenCongThanh_TSMoi", ds);
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
