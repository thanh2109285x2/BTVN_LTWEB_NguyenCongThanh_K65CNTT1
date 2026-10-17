using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NctK65Lesson09LA7.Models;

public partial class Banner
{
    [Key]
    [Display(Name = "Ma banner")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ten banner khong duoc de trong")]
    [StringLength(100, ErrorMessage = "Ten banner toi da 100 ky tu")]
    [Display(Name = "Ten banner")]
    public string Name { get; set; } = null!;

    [Display(Name = "Trang thai")]
    public byte? Status { get; set; }

    [Display(Name = "Do ưu tien")]
    public int? Prioty { get; set; }

    [StringLength(100, ErrorMessage = "Duong dan anh toi da 100 ky tu")]
    [Display(Name = "Hinh anh")]
    public string? Image { get; set; }

    [StringLength(350, ErrorMessage = "Mo ta toi da 350 ky tu")]
    [Display(Name = "Mo ta")]
    public string? Description { get; set; }
}