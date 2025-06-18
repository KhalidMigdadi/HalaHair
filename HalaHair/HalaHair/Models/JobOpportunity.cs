using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class JobOpportunity
{
    public int Id { get; set; }

    public int SalonId { get; set; }

    public string PositionEn { get; set; } = null!;

    public string PositionAr { get; set; } = null!;

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? LocationEn { get; set; }

    public string? LocationAr { get; set; }

    public decimal? Salary { get; set; }

    public string? RequirementsEn { get; set; }

    public string? RequirementsAr { get; set; }

    public bool IsActive { get; set; }
}
