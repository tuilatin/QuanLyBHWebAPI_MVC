using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class TbHoadon
{
    public int Mahoadon { get; set; }

    public int? Makhachhang { get; set; }

    public DateTime? Ngay { get; set; }

    public decimal? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public DateTime? Ngayduyet { get; set; }

    public string? Nguoiduyet { get; set; }

    public virtual TbKhanhhang? MakhachhangNavigation { get; set; }

    public virtual ICollection<TbChitiethoadon> TbChitiethoadon { get; set; } = new List<TbChitiethoadon>();
}
