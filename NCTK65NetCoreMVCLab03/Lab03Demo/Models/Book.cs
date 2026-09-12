using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace NCTK65NetCoreMVCLab03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        public List<Book> GetBooksList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chi Pheo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    Summary = "",
                    TotalPage = 250
                },
                new Book(){
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b2.png",
                    Price = 700000,
                    Summary = "",
                    TotalPage = 180
                },
                new Book(){
                    Id = 4,
                    Title = "Conan Phiêu lưu ký",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b3.png",
                    Price = 550000,
                    Summary = "",
                    TotalPage = 300
                },
                new Book(){
                    Id = 6,
                    Title = "Đường Xưa Mây Trắng",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b4.png",
                    Price = 850000,
                    Summary = "",
                    TotalPage = 450
                }
            };
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = this.GetBooksList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "Nam Cao"},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Adamkhoom"},
            new SelectListItem {Value="4", Text="Thiền sư Thích Nhất Hạnh"}
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="1", Text="Truyện tranh"},
            new SelectListItem{Value="2", Text="Văn học đương đại"},
            new SelectListItem{Value="3", Text="Phật học phổ thông"},
            new SelectListItem{Value="4", Text="Truyền cười"}
        };
    }
}
