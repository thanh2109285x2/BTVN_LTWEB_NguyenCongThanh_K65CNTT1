using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenCongThanh_241230844_De2026.Models;
using System.Diagnostics;

namespace NguyenCongThanh_241230844_De2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _ct;
        public HomeController(QlnhaSachContext context)
        {
            _ct = context;
        }
        public IActionResult Index()
        {
            ViewBag.TieuDe = "Nguyen Cong Thanh";
            var ds = _ct.Saches.Where(s => s.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult TimSach(int matl)
        {
            ViewBag.TieuDe = _ct.TheLoais.FirstOrDefault(t => t.MaTl == matl);
            var ds = _ct.Saches.Where(s => s.MaTl == matl).ToList();
            return PartialView("NguyenCongThanh_SachMoi", ds);
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
