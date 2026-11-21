using Microsoft.AspNetCore.Mvc;
using NguyenCongThanh_241230844_De2026_QLTS_DE2.Models;

namespace NguyenCongThanh_241230844_De2026_QLTS_DE2.ViewComponents
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
            ViewBag.TenSV = "NguyenCongThanh";
            return View(ds);
        }
    }
}
