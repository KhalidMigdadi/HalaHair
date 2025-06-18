using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class SubscriptionPackage
{
    public int Id { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public decimal Price { get; set; }

    public int DurationDays { get; set; }

    public int? MaxActiveBarbers { get; set; }

    public int? MaxPromotedServices { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
