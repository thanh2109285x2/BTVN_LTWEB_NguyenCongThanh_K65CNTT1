using Microsoft.AspNetCore.Mvc;
using NctK65Lesson10Lab1.Models;

namespace NctK65Lesson10Lab1.ViewComponents
{
    public class RenderLeftMenuViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderLeftMenuViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "Branches", Link = "Branch/Index" },
                new MenuItem() { Id = 2, Name = "Students", Link = "NctStudent/Index" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(MenuItems));
        }
    }
}