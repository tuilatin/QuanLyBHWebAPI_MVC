using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class TbGiohang
{
    public int Magiohang { get; set; }

    public int Makhachhang { get; set; }

    public DateTime? Ngaytao { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<TbChitietgiohang> TbChitietgiohang { get; set; } = new List<TbChitietgiohang>();
}
