using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NCTK65NetCoreMVCLab03BaiTapTuLam.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.Controllers
{
    public class NctProductController : Controller
    {
        private static List<NctProduct> _products = new List<NctProduct>
        {
            new NctProduct
            {
                NctId = 1,
                NctName = "Laptop Dell Inspiron 15",
                NctImage = "laptop-dell.jpg",
                NctCategoryId = 1,
                NctPrice = 15990000,
                NctScalePrice = 10,
                NctDescription = "Laptop văn phòng cấu hình ổn định, RAM 16GB, SSD 512GB, màn hình 15.6 inch Full HD."
            },
            new NctProduct
            {
                NctId = 2,
                NctName = "Chuột không dây Logitech M331",
                NctImage = "chuot-logitech.jpg",
                NctCategoryId = 2,
                NctPrice = 250000,
                NctScalePrice = 5,
                NctDescription = "Chuột không dây yên tĩnh, kết nối USB receiver, pin dùng được tới 24 tháng."
            },
            new NctProduct
            {
                NctId = 3,
                NctName = "Bàn phím cơ Keychron K2",
                NctImage = "ban-phim-keychron.jpg",
                NctCategoryId = 2,
                NctPrice = 1890000,
                NctScalePrice = 15,
                NctDescription = "Bàn phím cơ không dây layout 75%, kết nối Bluetooth, hỗ trợ cả Windows và macOS."
            }
        };

        // Sample categories list using NctCategory model
        private static List<NctCategory> _categories = new List<NctCategory>
        {
            new NctCategory { NctCategoryId = 1, NctName = "Laptops" },
            new NctCategory { NctCategoryId = 2, NctName = "Accessories" },
            new NctCategory { NctCategoryId = 3, NctName = "Smartphones" }
        };

        private readonly IWebHostEnvironment _env;

        public NctProductController(IWebHostEnvironment env)
        {
            _env = env;
        }


        // GET: NctProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: NctProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.NctId == id);
            return View(product);
        }

        // GET: NctProductController/Create
        public ActionResult Create()
        {
            LoadCategories();
            return View();
        }

        // POST: NctProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NctProduct product, IFormFile image)
        {
            // If an image file was uploaded, save it and assign to product before validation
            if (image != null && image.Length > 0)
            {
                product.NctImage = SaveImage(image);
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            product.NctId = _products.Any() ? _products.Max(p => p.NctId) + 1 : 1;
            _products.Add(product);

            return RedirectToAction(nameof(Index));
        }

        // GET: NctProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.NctId == id);
            if (product == null) return NotFound();
            LoadCategories();
            return View(product);
        }

        // POST: NctProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NctProduct product)
        {
            try
            {
                var editedProduct = _products.FirstOrDefault(p => p.NctId == id);
                if (editedProduct == null) return NotFound();

                if (!ModelState.IsValid)
                {
                    LoadCategories();
                    return View(product);
                }

                editedProduct.NctName = product.NctName;
                editedProduct.NctCategoryId = product.NctCategoryId;
                editedProduct.NctPrice = product.NctPrice;
                editedProduct.NctScalePrice = product.NctScalePrice;
                editedProduct.NctDescription = product.NctDescription;
                editedProduct.NctImage = product.NctImage;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void LoadCategories()
        {
            // NctCategory has properties: NctCategoryId and NctName
            ViewBag.NctCategoryId = new SelectList(_categories, "NctCategoryId", "NctName");
        }

        private string SaveImage(IFormFile image)
        {
            var uploads = Path.Combine(_env.WebRootPath ?? "wwwroot", "images");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return fileName;
        }

        // GET: NctProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.NctId == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: NctProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var product = _products.FirstOrDefault(p => p.NctId == id);
                if (product != null)
                {
                    _products.Remove(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
