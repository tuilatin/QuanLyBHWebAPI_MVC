using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class TbDanhmuc
{
    public int Madanhmuc { get; set; }

    public string? Tendanhmuc { get; set; }

    public int? Danhmuccha { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<TbSanpham> TbSanpham { get; set; } = new List<TbSanpham>();
}
