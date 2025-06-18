using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class LoyaltyPoint
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Points { get; set; }

    public int TotalEarned { get; set; }

    public int TotalRedeemed { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual User User { get; set; } = null!;
}
