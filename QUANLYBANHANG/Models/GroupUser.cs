using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class GroupUser
{
    public decimal IdGroup { get; set; }

    public string? GroupName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<GroupUserRelationshipUser> GroupUserRelationshipUser { get; set; } = new List<GroupUserRelationshipUser>();
}
