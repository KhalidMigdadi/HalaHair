using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class BarberService
{
    public int Id { get; set; }

    public int BarberId { get; set; }

    public int ServiceId { get; set; }

    public decimal Price { get; set; }

    public int Duration { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Barber { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
