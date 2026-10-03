using System.ComponentModel.DataAnnotations;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.Models
{
    public class NctProduct
    {
        public int NctId { get; set; }

        [
            Display(Name = "Tên sản phẩm"),
            Required(ErrorMessage = "Tên sản phẩm không được để trống"),
            StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự"),
            ]
        public string NctName { get; set; } = string.Empty;

        [
            Display(Name = "Hình ảnh"),
            Required(ErrorMessage = "Hình ảnh không được để trống")
            ]
        public string? NctImage { get; set; }


        public float NctPrice { get; set; }

        // Category Id for product
        public int NctCategoryId { get; set; }
        public int NctScalePrice { get; set; }

        [
            Display(Name = "Mô tả sản phẩm"),
            Required(ErrorMessage = "Mô tả sản phẩm không được để trống"),
            StringLength(1500, ErrorMessage = "Mô tả sản phẩm phải be hon 1500 ký tự")
            ]
        public string NctDescription { get; set; } = string.Empty;
    }
}