using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenCongThanh_241230844_De2026_QLTS.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    public string TenTs { get; set; } = null!;

    public decimal? NguyenGia { get; set; }

    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; } = null!;
}
