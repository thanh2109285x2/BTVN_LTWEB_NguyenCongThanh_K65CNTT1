using Microsoft.AspNetCore.Mvc;
using NctK65Lesson10Lab1.Models;
using NctK65Lesson10Lab1.Data;

namespace NctK65Lesson10Lab1.ViewComponents
{
    public class MajorViewComponent:ViewComponent
    {
        SchoolContext db;
        List<Major> majors;

        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajors", majors);
        }
    }
}
