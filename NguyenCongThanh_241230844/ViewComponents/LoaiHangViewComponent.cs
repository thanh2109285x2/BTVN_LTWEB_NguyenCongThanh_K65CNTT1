using Microsoft.AspNetCore.Mvc;
using NguyenCongThanh_241230844.Models;

namespace NguyenCongThanh_241230844.ViewComponents
{
    public class LoaiHangViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public LoaiHangViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var ds = _context.LoaiHangs.ToList();
            
            return View(ds);
        }
    }
}
