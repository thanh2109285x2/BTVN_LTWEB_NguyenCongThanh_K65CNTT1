using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NctK65Lesson09LA7.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ten danh muc khong duoc de trong")]
    [StringLength(100, ErrorMessage = "Ten danh muc toi da la 100 ky tu")]
    [Display(Name = "Ten danh muc")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Trang thai khong duoc de trong")]
    [Display(Name = "Trang thai")]
    public byte Status { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngay tao")]
    public DateOnly? CreatedDate { get; set; }

    [StringLength(255, ErrorMessage = "Duong dan anh toi da la 255 ky tu")]
    [Display(Name = "Hinh anh")]
    public string? Image { get; set; }

    [StringLength(350, ErrorMessage = "Mo ta toi da la 350 ky tu")]
    [Display(Name = "Mo ta")]
    public string? Description { get; set; }

    [BindNever]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}