using System;
using System.Collections.Generic;

namespace CUAHANGDIENTHOAI.Models;

public partial class DONHANG
{
    public int DONHANGID { get; set; }

    public int? KHACHHANGID { get; set; }

    public DateTime? NGAYDAT { get; set; }

    public string? TRANGTHAI { get; set; }

    public decimal? TAMTINH { get; set; }

    public decimal? PHISHIP { get; set; }

    public decimal? GIAMGIA { get; set; }

    public decimal? TONGTIEN { get; set; }

    public string? TENNGUOINHAN { get; set; }

    public string? DIENTHOAINGUOINHAN { get; set; }

    public string? DIACHINHAN { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual KHACHHANG? KHACHHANG { get; set; }
}
