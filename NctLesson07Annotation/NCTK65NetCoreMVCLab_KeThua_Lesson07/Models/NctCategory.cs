using System.ComponentModel.DataAnnotations;

namespace NCTK65NetCoreMVCLab03BaiTapTuLam.Models
{
    public class NctCategory
    {
        [
            Display(Name = "Mã danh mục"),
            Required(ErrorMessage = "Mã danh mục không được để trống"),
            ]
        public int NctCategoryId { get; set; }
        public string NctName { get; set; } = string.Empty;
    }
}
