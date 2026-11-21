using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenCongThanh_241230844_De2026_QLTS_DE2.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    [Required( ErrorMessage ="ko dc trong")]
    public string TenTs { get; set; } = null!;

    [Range(1,2000, ErrorMessage =" tu 1 den 2000")]
    public decimal? NguyenGia { get; set; }

    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp)$", ErrorMessage ="ten file sai")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; } = null!;
}
