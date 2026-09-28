using Microsoft.AspNetCore.Mvc;
using NctLesson07AnnotationDemo.Models;

namespace NctLesson07AnnotationDemo.Controllers
{
    public class NctMemberController : Controller
    {
        public static readonly List<NctMember> NctMembers = new List<NctMember>(); 
        public IActionResult Index()
        {
            return View(NctMembers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NctMember member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NctMember m = new NctMember
                    {
                        Id = NctMembers.Count + 1,
                        NctName = member.NctName,
                        NctPassword = member.NctPassword,
                        NctConfirmPassword = member.NctConfirmPassword,
                        NctEmail = member.NctEmail,
                        NctPhone = member.NctPhone
                    };
                    NctMembers.Add(m);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(member);
                }
            }
            catch
            {
                return View(member);
            }
        }

        public IActionResult Details(int id)
        {
            var m  = NctMembers.FirstOrDefault(m => m.Id == id);
            if (m == null)
            {
                return NotFound();
            }
            return View(m);
        }
    }
}
