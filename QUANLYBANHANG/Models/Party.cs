using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class Party
{
    public decimal PartyId { get; set; }

    public string TypeOfParty { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UsernameH { get; set; }

    public string? PasswordH { get; set; }

    public virtual ICollection<GroupUserRelationshipUser> GroupUserRelationshipUser { get; set; } = new List<GroupUserRelationshipUser>();

    public virtual Person? Person { get; set; }
}
