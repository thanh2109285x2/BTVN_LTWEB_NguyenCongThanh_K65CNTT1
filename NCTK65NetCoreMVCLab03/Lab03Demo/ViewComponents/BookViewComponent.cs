using Microsoft.AspNetCore.Mvc;
using NCTK65NetCoreMVCLab03.Models;

namespace NCTK65NetCoreMVCLab03.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();

        public IViewComponentResult Invoke()
        {
            var books = book.GetBooksList();
            return View(books);
        }
    }
}