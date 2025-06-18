using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class BookingsHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BarberId { get; set; }

    public int SalonId { get; set; }

    public int? ServiceId { get; set; }

    public DateOnly BookingDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int? TotalDuration { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Barber { get; set; } = null!;

    public virtual Salon Salon { get; set; } = null!;

    public virtual Service? Service { get; set; }

    public virtual User User { get; set; } = null!;
}
