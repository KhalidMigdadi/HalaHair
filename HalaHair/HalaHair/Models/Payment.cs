using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public int UserId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? TransactionId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public bool IsRefunded { get; set; }

    public string? SecurityCodeHash { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
