using Microsoft.AspNetCore.Mvc;

namespace NctK65NetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }
    }
}
