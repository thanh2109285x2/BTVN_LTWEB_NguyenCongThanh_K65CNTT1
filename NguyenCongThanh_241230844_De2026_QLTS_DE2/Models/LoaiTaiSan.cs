using System;
using System.Collections.Generic;

namespace NguyenCongThanh_241230844_De2026_QLTS_DE2.Models;

public partial class LoaiTaiSan
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}
