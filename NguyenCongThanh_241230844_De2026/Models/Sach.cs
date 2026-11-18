using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NguyenCongThanh_241230844_De2026.Models;

public partial class Sach
{
    [Key]
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    public string TenSach { get; set; } = null!;

    public decimal? Gia { get; set; }

    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
