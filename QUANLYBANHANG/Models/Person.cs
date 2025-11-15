using System;
using System.Collections.Generic;

namespace QUANLYBANHANG.Models;

public partial class Person
{
    public decimal PartyId { get; set; }

    public string? CurrentLastName { get; set; }

    public string? CurrentFirstName { get; set; }

    public string? CurrentMiddleName { get; set; }

    public string? CurrentNickname { get; set; }

    public decimal? CurrentGenderTypeId { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? PeopleIdNumber { get; set; }

    public DateTime? PeopleIdIssueDate { get; set; }

    public string? PeopleIdIssuePlace { get; set; }

    public string? CurrentPhoneNumber { get; set; }

    public string? CurrentEmail { get; set; }

    public string? PersonImage { get; set; }

    public virtual Party Party { get; set; } = null!;
}
