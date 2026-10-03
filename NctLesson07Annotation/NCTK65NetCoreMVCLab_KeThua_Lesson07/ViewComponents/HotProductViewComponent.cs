using NCTK65NetCoreMVCLab03BaiTapTuLam.Models;
using Microsoft.AspNetCore.Mvc;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = new List<NctProduct>
            {
                new NctProduct { NctId = 1, NctName = "Nồi cơm điện cao tần Nagakawa NAG0102", NctImage = "/images/noicom.png" },
                new NctProduct { NctId = 2, NctName = "Nồi cơm điện cao tần Nagakawa NAG0102", NctImage = "/images/noicom.png" },
                new NctProduct { NctId = 3, NctName = "Nồi cơm điện cao tần Nagakawa NAG0102", NctImage = "/images/noicom.png" }
            };
            return View(hotProducts);
        }
    }
}
