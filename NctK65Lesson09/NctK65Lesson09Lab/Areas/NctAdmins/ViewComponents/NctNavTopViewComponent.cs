using Microsoft.AspNetCore.Mvc;

namespace NctK65Lesson09LA7.Areas.NctAdmins.ViewComponents
{
    public class NctNavTopViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
