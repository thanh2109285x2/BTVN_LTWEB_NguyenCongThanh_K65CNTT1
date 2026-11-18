using Microsoft.AspNetCore.Mvc;
using NguyenCongThanh_241230844_De2026.Models;
using System.Net.Quic;

namespace NguyenCongThanh_241230844_De2026.ViewComponents
{
    public class NguyenCongThanh_MenuViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext _ct;
        public NguyenCongThanh_MenuViewComponent(QlnhaSachContext context)
        {
            _ct = context;
        }
        public IViewComponentResult Invoke()
        {
            var ds = _ct.TheLoais.ToList();
            ViewBag.TenSV = "Nguyen Cong Thanh";
            return View(ds);
        }
    }
}
