using Microsoft.AspNetCore.Mvc;
using NguyenCongThanh_241230844_De2026_QLTS.Models;

namespace NguyenCongThanh_241230844_De2026_QLTS.ViewComponents
{
    public class NguyenCongThanh_MenuViewComponent : ViewComponent
    {
        private readonly QltaiSanContext _ct;
        public NguyenCongThanh_MenuViewComponent(QltaiSanContext ct)
        {
            _ct = ct;
        }
        public IViewComponentResult Invoke()
        {
            var ds = _ct.LoaiTaiSans.ToList();
            ViewBag.TenSV = "Nguyen Cong Thanh";
            return View(ds);
        }
    }
}
