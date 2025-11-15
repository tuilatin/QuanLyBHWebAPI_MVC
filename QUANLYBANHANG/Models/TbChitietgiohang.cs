using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class TbChitietgiohang
{
    public int Magiohang { get; set; }

    public int Masanpham { get; set; }

    public int Soluong { get; set; }

    public decimal Dongia { get; set; }

    public decimal? Thanhtien { get; set; }

    public virtual TbGiohang MagiohangNavigation { get; set; } = null!;

    public virtual TbSanpham MasanphamNavigation { get; set; } = null!;
}
