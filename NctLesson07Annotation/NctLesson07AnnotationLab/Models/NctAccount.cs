using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NctLesson07AnnotationLab.Models
{
    public class NctAccount
    {
        [Key]
        public int Id { get; set; }
        [
            Display(Name = "Ho va ten"),
            Required(ErrorMessage = "Ho va ten khong duoc de trong"),
            MinLength(6, ErrorMessage = "do dai ten khong duoc duoi 6 ky tu"),
            MaxLength(20, ErrorMessage = "do dai ten khong duoc qua 20 ky tu")
        ]
        public string NctName { get; set; }

        [
            Display(Name = "Email"),
            Required(ErrorMessage = "Email khong duoc de trong"),
            EmailAddress(ErrorMessage = "Email khong hop le")
        ]
        public string NctEmail { get; set; }
        [
            Display(Name = "So dien thoai"),
            DataType(DataType.PhoneNumber),
            Required(ErrorMessage = "So dien thoai khong duoc de trong"),
            Remote(action: "VerifyPhone", controller: "NctAccount", ErrorMessage = "So dien thoai ko hop le")
        ]
        public string NctPhone { get; set; }

        [
            Display(Name = "Dia chi"),
            Required(ErrorMessage = "Dia chi khong duoc de trong"),
            StringLength(35, MinimumLength = 10, ErrorMessage = "Dia chi phai tu 10 den 35 ky tu")
        ]
        public string NctAddress { get; set; }

        [Display(Name ="anh dai dien")]
        public string NctAvatar { get; set; }
        [
            Display(Name = "Ngay sinh"),
            Required(ErrorMessage = "Ngay sinh khong duoc de trong"),
            DataType(DataType.Date, ErrorMessage = "Ngay sinh khong hop le")
            ]
        public DateTime NctBirthDay { get; set; }

        [Display(Name = "Gioi tinh")]
        public string NctGender { get; set; }

        [Display(Name = "Mat khau")]
        public string NctPassword { get; set; }

        [
            Display(Name = "link Facebook ca nhan"),
            Url(ErrorMessage = "link Facebook khong hop le, dinh dang : https://www.facebook.com/...")
            ]
        public string NctFacebook { get; set; }

    }
}
