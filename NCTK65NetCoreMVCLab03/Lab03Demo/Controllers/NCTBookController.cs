using Microsoft.AspNetCore.Mvc;
using NCTK65NetCoreMVCLab03.Models;

namespace NCTK65NetCoreMVCLab03.Controllers
{
    public class NCTBookController : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            List<Book> books = book.GetBooksList();
            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }
        public IActionResult Edit(int id) 
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }
        public PartialViewResult PopularBook()
        {
            List<Book> books = book.GetBooksList();
            return PartialView(books);
        }
    }
}
