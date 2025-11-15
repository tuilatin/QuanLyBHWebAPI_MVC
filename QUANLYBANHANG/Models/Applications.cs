using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class Applications
{
    public decimal IdApplication { get; set; }

    public string? ApplicationName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<MenuForm> IdMenuForm { get; set; } = new List<MenuForm>();
}
