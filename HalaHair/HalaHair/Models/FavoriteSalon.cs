using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class FavoriteSalon
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SalonId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Salon Salon { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
