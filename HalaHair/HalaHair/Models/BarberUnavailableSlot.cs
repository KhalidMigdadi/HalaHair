using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class BarberUnavailableSlot
{
    public int Id { get; set; }

    public int BarberId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? Reason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Barber { get; set; } = null!;
}
