using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class TbKhanhhang
{
    public int Makhachhang { get; set; }

    public string? Hoten { get; set; }

    public DateOnly? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Email { get; set; }

    public string? Diachi { get; set; }

    public string? Taikhoan { get; set; }

    public string? Matkhau { get; set; }

    public virtual ICollection<TbHoadon> TbHoadon { get; set; } = new List<TbHoadon>();
}
