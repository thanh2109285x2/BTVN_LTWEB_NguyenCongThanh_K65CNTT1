using NCTK65NetCoreMVCLab03BaiTapTuLam.Models;
using Microsoft.AspNetCore.Mvc;
using NCTK65NetCoreMVCLab03BaiTapTuLam.Models;
using System.Diagnostics;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var newProducts = new List<Product>
            {
                new Product { Id = 101, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noicom.png" },
                new Product { Id = 102, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noicom.png" },
                new Product { Id = 103, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noicom.png" }
            };
            return View(newProducts);
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
