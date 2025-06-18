using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public int SalonId { get; set; }

    public int PackageId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = null!;

    public bool AutoRenew { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SubscriptionPackage Package { get; set; } = null!;

    public virtual Salon Salon { get; set; } = null!;
}
