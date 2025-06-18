using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class Service
{
    public int Id { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string? Gender { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public int Duration { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int SalonId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<BarberService> BarberServices { get; set; } = new List<BarberService>();

    public virtual ICollection<BookingsHistory> BookingsHistories { get; set; } = new List<BookingsHistory>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<FavoriteService> FavoriteServices { get; set; } = new List<FavoriteService>();

    public virtual Salon Salon { get; set; } = null!;
}
