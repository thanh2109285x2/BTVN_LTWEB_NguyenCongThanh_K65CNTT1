using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NctLesson07AnnotationLab.Models;
using System.Text.RegularExpressions;

namespace NctLesson07AnnotationLab.Controllers
{
    public class NctAccountController : Controller
    {
        // GET: NctAccountController
        public ActionResult Index()
        {
            List<NctAccount> accounts = new List<NctAccount>();
            return View(accounts);
        }

        // GET: NctAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NctAccountController/Create
        public ActionResult Create()
        {
            NctAccount model = new NctAccount();
            return View(model);
        }

        // POST: NctAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NctAccount model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NctAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NctAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NctAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NctAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string NctPhone)
        {
            Regex _isPhone = new Regex(@"^0([0-9]{2})[-.]?([0-9]{4})[-.]?([0-9]{3})$");

            if(!_isPhone.IsMatch(NctPhone))
            {
                return Json($"So dien thoai {NctPhone} khong hop le");
            }

            return Json(true);
        }
    }
}
