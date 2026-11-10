using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenCongThanh_241230844.Models;

public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Range(100, 5000, ErrorMessage ="Gia phai trong 100 den 5000")]

    public decimal? Gia { get; set; }

    [RegularExpression(@"^.+\.(jpg|png|.gif|.tiff)$")]
    public string? Anh { get; set; }

    public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
}
