using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NctK65Lesson09LA7.Models;

public partial class Product
{
    [Key]
    [Display(Name = "Ma san pham")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ten san pham khong duoc de trong")]
    [StringLength(100, ErrorMessage = "Ten san pham toi da la 100 ky tu")]
    [Display(Name = "Ten san pham")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Gia san pham khong duoc de trong")]
    [Range(0, double.MaxValue, ErrorMessage = "Gia san pham phai lon hon hoac bang 0")]
    [Display(Name = "Gia san pham")]
    public double Price { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Gia khuyen mai phai lon hon hoac bang 0")]
    [Display(Name = "Gia khuyen mai")]
    public double? SalePrice { get; set; }

    [Display(Name = "Trang thai")]
    public byte? Status { get; set; }

    [Required(ErrorMessage = "Vui long chon danh muc")]
    [Display(Name = "Danh muc")]
    public int CategoryId { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngay tao")]
    public DateOnly? CreatedDate { get; set; }

    [StringLength(100, ErrorMessage = "Duong dan anh toi da 100 ky tu")]
    [Display(Name = "Hinh anh")]
    public string? Image { get; set; }

    [StringLength(350, ErrorMessage = "Mo ta toi da 350 ky tu")]
    [Display(Name = "Mo ta")]
    public string? Description { get; set; }

    [BindNever]
    [ValidateNever]
    public virtual Category Category { get; set; }
}