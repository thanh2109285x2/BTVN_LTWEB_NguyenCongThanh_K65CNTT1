using NCTK65NetCoreMVCLab03BaiTapTuLam.Models;
using Microsoft.AspNetCore.Mvc;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noicom.png" },
                new Product { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noicom.png" },
                new Product { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noicom.png" }
            };
            return View(hotProducts);
        }
    }
}
