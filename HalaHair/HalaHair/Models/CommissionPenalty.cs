using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class CommissionPenalty
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public string PenalizedParty { get; set; } = null!;

    public int? UserId { get; set; }

    public int? BarberId { get; set; }

    public decimal Amount { get; set; }

    public decimal? Percentage { get; set; }

    public string? Reason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual User? Barber { get; set; }

    public virtual User? User { get; set; }
}
