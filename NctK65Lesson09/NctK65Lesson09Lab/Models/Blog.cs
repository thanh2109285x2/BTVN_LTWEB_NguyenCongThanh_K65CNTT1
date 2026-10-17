using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NctK65Lesson09LA7.Models;

public partial class Blog
{
    [Key]
    [Display(Name = "Ma bai viet")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ten bai viet khong duoc de trong")]
    [StringLength(100, ErrorMessage = "Ten bai viet toi da 100 ky tu")]
    [Display(Name = "Ten bai viet")]
    public string Name { get; set; } = null!;

    [Display(Name = "Trang thai")]
    public byte? Status { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngay tao")]
    public DateOnly? CreatedDate { get; set; }

    [StringLength(100, ErrorMessage = "Duong dan anh toi da 100 ky tu")]
    [Display(Name = "Hinh anh")]
    public string? Image { get; set; }

    [StringLength(350, ErrorMessage = "Mo ta toi da 350 ky tu")]
    [Display(Name = "Mo ta")]
    public string? Description { get; set; }
}