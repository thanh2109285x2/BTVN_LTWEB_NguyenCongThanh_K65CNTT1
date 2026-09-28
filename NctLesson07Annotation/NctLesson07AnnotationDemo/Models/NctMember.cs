using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NctLesson07AnnotationDemo.Models
{
    public class NctMember
    {
        public int Id { get; set; }
        [DisplayName ("Tai khoan")]
        [Required(ErrorMessage = "Tai khoan khong duoc de trong")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tai khoan phai tu 3 den 20 ky tu")]
        public string? NctName { get; set; }
        [DisplayName ("Mat khau")]
        [Required(ErrorMessage = "Mat khau khong duoc de trong")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mat khau phai tu 8 den 100 ky tu")]
        public string? NctPassword { get; set; }
        [DisplayName("Xac nhan mat khau")]
        [Compare("NctPassword", ErrorMessage = "Xac nhan mat khau khong chinh xac")]
        public string? NctConfirmPassword { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email khong duoc de trong")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email khong hop le")]
        [EmailAddress(ErrorMessage = "Email khong hop le")]
        public string? NctEmail { get; set; }
        [DisplayName("So dien thoai")]
        [Required(ErrorMessage = "So dien thoai khong duoc de trong")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "So dien thoai khong hop le")]
        public string? NctPhone { get; set; }
    }
}
