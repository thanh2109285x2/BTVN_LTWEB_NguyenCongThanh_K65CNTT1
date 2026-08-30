using Microsoft.AspNetCore.Mvc;
using NctLesson03.Models;

namespace NctLesson03.Controllers
{
    [Route("san-pham")]
    public class NctProductController : Controller
    {
        private List<NctProduct> GetProductList()
        {
            return new List<NctProduct>
            {
                new NctProduct{Id = 1, Name = "Bộ đồ bơi cho trẻ em nam", OldPrice = 50000, NewPrice = 35000, ImageUrl = "/images/1.png", Status = "Còn hàng", CreatedDate = new DateTime(2021, 7, 15, 12, 0, 0), Category = "Cloth" },
                new NctProduct{Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ", OldPrice = 50000, NewPrice = 35000, ImageUrl = "/images/2.png", Status = "Còn hàng", CreatedDate = new DateTime(2021, 7, 15, 12, 0, 0), Category = "Cloth" },
                new NctProduct{Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi", OldPrice = 50000, NewPrice = 35000, ImageUrl = "/images/3.png", Status = "Còn hàng", CreatedDate = new DateTime(2021, 7, 15, 12, 0, 0), Category = "Cloth" },
                new NctProduct{Id = 4, Name = "Bộ đồ bơi cho trẻ em thời trang", OldPrice = 50000, NewPrice = 35000, ImageUrl = "/images/4.png", Status = "Còn hàng", CreatedDate = new DateTime(2021, 7, 15, 12, 0, 0), Category = "Cloth" },
                new NctProduct{Id = 5, Name = "Túi thời trang mẫu mới 2021", OldPrice = 50000, NewPrice = 35000, ImageUrl = "/images/5.png", Status = "Còn hàng", CreatedDate = new DateTime(2021, 7, 15, 12, 0, 0), Category = "HandBag" },
                new NctProduct{Id = 6, Name = "Túi thời trang da cá sấu", OldPrice = 50000, NewPrice = 35000, ImageUrl = "/images/6.png", Status = "Còn hàng", CreatedDate = new DateTime(2021, 7, 15, 12, 0, 0), Category = "HandBag" }
            };
        }
        private List<string> GetCategoryList()
        {
            return new List<string> { "Cloth", "HandBag", "Watch", "Tv", "Fridge", "Pump", "Fan", "Heater" };
        }
        [HttpGet("")]
        public IActionResult Index(string? category)
        {
            var products = GetProductList();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.Products = products;
            ViewBag.Categories = GetCategoryList();
            return View();
        }
        [HttpGet("chi-tiet/id={id}")]
        public IActionResult Detail(int id)
        {
            var products = GetProductList();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Product = product;
            return View();
        }
    }
}
