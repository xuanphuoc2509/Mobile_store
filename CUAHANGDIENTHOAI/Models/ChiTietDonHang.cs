using System;
using System.Collections.Generic;

namespace CUAHANGDIENTHOAI.Models;

public partial class ChiTietDonHang
{
    public long CHITIETID { get; set; }

    public int? DONHANGID { get; set; }

    public int? SANPHAMID { get; set; }

    public int SOLUONG { get; set; }

    public decimal DONGIA { get; set; }

    public decimal? THANHTIEN { get; set; }

    public virtual DONHANG? DONHANG { get; set; }

    public virtual SANPHAM? SANPHAM { get; set; }
}
