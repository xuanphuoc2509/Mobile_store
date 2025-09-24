using System;
using System.Collections.Generic;

namespace CUAHANGDIENTHOAI.Models;

public partial class KHACHHANG
{
    public int KHACHHANGID { get; set; }

    public string? HOTEN { get; set; }

    public string? EMAIL { get; set; }

    public string? DIENTHOAI { get; set; }

    public DateTime? NGAYTAO { get; set; }

    public virtual ICollection<DONHANG> DONHANGs { get; set; } = new List<DONHANG>();
}
