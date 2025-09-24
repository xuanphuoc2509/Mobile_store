using System;
using System.Collections.Generic;

namespace CUAHANGDIENTHOAI.Models;

public partial class HANG
{
    public int HANGID { get; set; }

    public string? TenHang { get; set; }

    public virtual ICollection<SANPHAM> SANPHAMs { get; set; } = new List<SANPHAM>();
}
