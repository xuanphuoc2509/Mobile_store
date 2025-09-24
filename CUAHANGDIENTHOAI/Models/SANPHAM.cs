using System;
using System.Collections.Generic;

namespace CUAHANGDIENTHOAI.Models;

public partial class SANPHAM
{
    public int SANPHAMID { get; set; }

    public int? HANGID { get; set; }

    public string? TENSANPHAM { get; set; }

    public decimal? GIA { get; set; }

    public int? TONKHO { get; set; }

    public string? TRANGTHAI { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual HANG? HANG { get; set; }
}
