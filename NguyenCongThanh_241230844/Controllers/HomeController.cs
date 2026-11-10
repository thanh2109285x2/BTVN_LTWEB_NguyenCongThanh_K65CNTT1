using Microsoft.AspNetCore.Mvc;
using NguyenCongThanh_241230844.Models;
using System.Diagnostics;

namespace NguyenCongThanh_241230844.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _ct;
        public HomeController (QlhangHoaContext ct)
        {
            _ct = ct;
        }
        public IActionResult Index()
        {
            ViewBag.TenSV = "NguyenCongThanh";
            var ds = _ct.HangHoas.Where(hang => hang.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult TheoLoai(int id)
        {
            var ds = _ct.HangHoas.Where(h => h.MaLoai == id).ToList();
            return PartialView("HangHoa", ds);
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
