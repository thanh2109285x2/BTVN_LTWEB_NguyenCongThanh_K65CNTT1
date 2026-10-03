using NCTK65NetCoreMVCLab03BaiTapTuLam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var newProducts = new List<NctProduct>
            {
                new NctProduct { NctId = 101, NctName = "Nồi cơm điện cao tần Nagakawa NAG0102", NctImage = "/images/noicom.png" },
                new NctProduct { NctId = 102, NctName = "Nồi cơm điện cao tần Nagakawa NAG0102", NctImage = "/images/noicom.png" },
                new NctProduct { NctId = 103, NctName = "Nồi cơm điện cao tần Nagakawa NAG0102", NctImage = "/images/noicom.png" }
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
