using Microsoft.AspNetCore.Mvc;

namespace NctK65Lesson09LA7.Areas.NctAdmins.Controllers
{
    [Area("NctAdmins")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
