using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class Review
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BarberId { get; set; }

    public int SalonId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Barber { get; set; } = null!;

    public virtual Salon Salon { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
