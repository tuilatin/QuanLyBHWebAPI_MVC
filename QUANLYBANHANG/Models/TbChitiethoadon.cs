using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class TbChitiethoadon
{
    public int Machitiet { get; set; }

    public int? Masanpham { get; set; }

    public decimal? Soluong { get; set; }

    public decimal? Dongia { get; set; }

    public int? Mahoadon { get; set; }

    public virtual TbHoadon? MahoadonNavigation { get; set; }

    public virtual TbSanpham? MasanphamNavigation { get; set; }
}
